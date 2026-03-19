using Microsoft.EntityFrameworkCore;
using Feedback.model;
using System.Linq.Expressions;

namespace Feedback.repo;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<VOC> VOC => Set<VOC>();
    public DbSet<Listening> Listening => Set<Listening>();
    public DbSet<ListeningSentenceDetail> ListeningSentenceDetail => Set<ListeningSentenceDetail>();
    public DbSet<Reading> Reading => Set<Reading>();
    public DbSet<ReadingSentenceDetail> ReadingSentenceDetail => Set<ReadingSentenceDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Entity<ListeningSentenceDetail>()
            .HasOne(d => d.Listening)
            .WithMany(l => l.SentenceDetails)
            .HasForeignKey(d => d.ListeningId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReadingSentenceDetail>()
            .HasOne(d => d.Reading)
            .WithMany(r => r.SentenceDetails)
            .HasForeignKey(d => d.ReadingId)
            .OnDelete(DeleteBehavior.Cascade);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            if (clrType == null) continue;

            var deletedProp = clrType.GetProperty("Deleted");
            if (deletedProp != null && (deletedProp.PropertyType == typeof(bool) || deletedProp.PropertyType == typeof(bool?)))
            {
                modelBuilder.Entity(clrType).Property("Deleted").HasDefaultValue(false);

                var parameter = Expression.Parameter(clrType, "e");
                var efPropertyMethod = typeof(EF).GetMethod("Property", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)?.MakeGenericMethod(typeof(bool));
                if (efPropertyMethod != null)
                {
                    var call = Expression.Call(efPropertyMethod, parameter, Expression.Constant("Deleted"));
                    var body = Expression.Equal(call, Expression.Constant(false));
                    var lambda = Expression.Lambda(body, parameter);
                    modelBuilder.Entity(clrType).HasQueryFilter(lambda);
                }
            }
        }
    }

    public override int SaveChanges()
    {
        ApplyAuditInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditInfo()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
        var now = DateTime.Now;

        foreach (var entry in entries)
        {
            var createdAtMeta = entry.Metadata.FindProperty("CreatedAt");
            if (createdAtMeta != null && entry.State == EntityState.Added)
            {
                var prop = entry.Property("CreatedAt");
                if (prop.CurrentValue == null || (DateTime)prop.CurrentValue! == default(DateTime))
                    prop.CurrentValue = now;
            }
            var createdDateMeta = entry.Metadata.FindProperty("CreatedDate");
            if (createdDateMeta != null && entry.State == EntityState.Added)
            {
                var prop = entry.Property("CreatedDate");
                if (prop.CurrentValue == null || (DateTime)prop.CurrentValue! == default(DateTime))
                    prop.CurrentValue = now;
            }
            var updatedAtMeta = entry.Metadata.FindProperty("UpdatedAt");
            if (updatedAtMeta != null)
                entry.Property("UpdatedAt").CurrentValue = now;
            var updatedDateMeta = entry.Metadata.FindProperty("UpdatedDate");
            if (updatedDateMeta != null)
                entry.Property("UpdatedDate").CurrentValue = now;
        }
    }
}
