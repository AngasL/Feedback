using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Feedback.repo;
using Feedback.service;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001);
});

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Connection string 'Default' not found.");

var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, serverVersion, mySqlOptions =>
    {
        mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
    });
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});

builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Feedback API", Version = "v1" });
    c.TagActionsBy(api =>
    {
        var path = api.RelativePath ?? "";
        if (path.Contains("voc")) return ["voc"];
        if (path.Contains("listening")) return ["listening"];
        if (path.Contains("reading")) return ["reading"];
        return [api.GroupName ?? "other"];
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("frontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:8080", "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("EnableSwagger", false))
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feedback API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("frontend");

app.MapGet("/health", () => Results.Ok(new { status = "ok", service = "Feedback", time = DateTime.Now }));

app.MapControllers();

app.Run();
