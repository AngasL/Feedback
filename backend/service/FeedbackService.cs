using Feedback.model;
using Feedback.repo;
using Microsoft.EntityFrameworkCore;

namespace Feedback.service;

public class FeedbackService : IFeedbackService
{
    private readonly AppDbContext _db;

    public FeedbackService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<VOC>> GetAllVOCsAsync(int? teacherId = null, int? studentId = null, CancellationToken ct = default)
    {
        var query = _db.VOC.AsQueryable();
        if (teacherId.HasValue) query = query.Where(x => x.TeacherId == teacherId.Value);
        if (studentId.HasValue) query = query.Where(x => x.StudentId == studentId.Value);
        return await query.OrderByDescending(x => x.CreatedDate).ToListAsync(ct);
    }

    public async Task<VOC?> GetVOCByIdAsync(int id, CancellationToken ct = default)
        => await _db.VOC.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<int> CreateVOCAsync(VOC item, CancellationToken ct = default)
    {
        _db.VOC.Add(item);
        await _db.SaveChangesAsync(ct);
        return item.Id;
    }

    public async Task<bool> UpdateVOCAsync(int id, VOC item, CancellationToken ct = default)
    {
        var entity = await _db.VOC.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.TeacherId = item.TeacherId;
        entity.StudentId = item.StudentId;
        entity.Correct = item.Correct;
        entity.Screening = item.Screening;
        entity.Total = item.Total;
        entity.SetCount = item.SetCount;
        entity.IncorrectWords = item.IncorrectWords;
        entity.TimeConsumed = item.TimeConsumed;
        entity.IsPass = item.IsPass;
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteVOCAsync(int id, CancellationToken ct = default)
    {
        var entity = await _db.VOC.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.Deleted = true;
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<List<Listening>> GetAllListeningsAsync(int? teacherId = null, int? studentId = null, CancellationToken ct = default)
    {
        var query = _db.Listening.AsQueryable();
        if (teacherId.HasValue) query = query.Where(x => x.TeacherId == teacherId.Value);
        if (studentId.HasValue) query = query.Where(x => x.StudentId == studentId.Value);
        return await query.OrderByDescending(x => x.CreatedDate).ToListAsync(ct);
    }

    public async Task<Listening?> GetListeningByIdAsync(int id, bool includeDetails = false, CancellationToken ct = default)
    {
        var query = _db.Listening.AsQueryable();
        if (includeDetails) query = query.Include(x => x.SentenceDetails);
        return await query.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<int> CreateListeningAsync(Listening item, CancellationToken ct = default)
    {
        _db.Listening.Add(item);
        await _db.SaveChangesAsync(ct);
        return item.Id;
    }

    public async Task<bool> UpdateListeningAsync(int id, Listening item, CancellationToken ct = default)
    {
        var entity = await _db.Listening.Include(x => x.SentenceDetails).FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.TeacherId = item.TeacherId;
        entity.StudentId = item.StudentId;
        entity.SentenceType = item.SentenceType;
        entity.ArticleTitle = item.ArticleTitle;
        entity.Screening = item.Screening;
        entity.Total = item.Total;
        entity.ArticleCount = item.ArticleCount;
        entity.MarkSentenceCount = item.MarkSentenceCount;
        entity.QuestionCount = item.QuestionCount;
        entity.QuestionCorrectCount = item.QuestionCorrectCount;
        entity.NotesSummary = item.NotesSummary;
        if (item.SentenceDetails?.Count > 0)
        {
            entity.SentenceDetails.Clear();
            foreach (var d in item.SentenceDetails)
            {
                entity.SentenceDetails.Add(new ListeningSentenceDetail
                {
                    ListeningId = entity.Id,
                    SentenceId = d.SentenceId,
                    PlayCount = d.PlayCount,
                    Vocabularies = d.Vocabularies,
                    SentenceContent = d.SentenceContent,
                    Notes = d.Notes
                });
            }
        }
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteListeningAsync(int id, CancellationToken ct = default)
    {
        var entity = await _db.Listening.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.Deleted = true;
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<List<ListeningSentenceDetail>> GetAllListeningSentenceDetailsAsync(int? listeningId = null, CancellationToken ct = default)
    {
        var query = _db.ListeningSentenceDetail.AsQueryable();
        if (listeningId.HasValue) query = query.Where(x => x.ListeningId == listeningId.Value);
        return await query.OrderBy(x => x.Id).ToListAsync(ct);
    }

    public async Task<ListeningSentenceDetail?> GetListeningSentenceDetailByIdAsync(int id, CancellationToken ct = default)
        => await _db.ListeningSentenceDetail.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<int> CreateListeningSentenceDetailAsync(ListeningSentenceDetail item, CancellationToken ct = default)
    {
        _db.ListeningSentenceDetail.Add(item);
        await _db.SaveChangesAsync(ct);
        return item.Id;
    }

    public async Task<bool> UpdateListeningSentenceDetailAsync(int id, ListeningSentenceDetail item, CancellationToken ct = default)
    {
        var entity = await _db.ListeningSentenceDetail.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.ListeningId = item.ListeningId;
        entity.SentenceId = item.SentenceId;
        entity.PlayCount = item.PlayCount;
        entity.Vocabularies = item.Vocabularies;
        entity.SentenceContent = item.SentenceContent;
        entity.Notes = item.Notes;
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteListeningSentenceDetailAsync(int id, CancellationToken ct = default)
    {
        var entity = await _db.ListeningSentenceDetail.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        _db.ListeningSentenceDetail.Remove(entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<List<Reading>> GetAllReadingsAsync(int? teacherId = null, int? studentId = null, CancellationToken ct = default)
    {
        var query = _db.Reading.AsQueryable();
        if (teacherId.HasValue) query = query.Where(x => x.TeacherId == teacherId.Value);
        if (studentId.HasValue) query = query.Where(x => x.StudentId == studentId.Value);
        return await query.OrderByDescending(x => x.CreatedDate).ToListAsync(ct);
    }

    public async Task<Reading?> GetReadingByIdAsync(int id, bool includeDetails = false, CancellationToken ct = default)
    {
        var query = _db.Reading.AsQueryable();
        if (includeDetails) query = query.Include(x => x.SentenceDetails);
        return await query.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<int> CreateReadingAsync(Reading item, CancellationToken ct = default)
    {
        _db.Reading.Add(item);
        await _db.SaveChangesAsync(ct);
        return item.Id;
    }

    public async Task<bool> UpdateReadingAsync(int id, Reading item, CancellationToken ct = default)
    {
        var entity = await _db.Reading.Include(x => x.SentenceDetails).FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.TeacherId = item.TeacherId;
        entity.StudentId = item.StudentId;
        entity.SentenceType = item.SentenceType;
        entity.ArticleTitle = item.ArticleTitle;
        entity.Screening = item.Screening;
        entity.Total = item.Total;
        entity.ArticleCount = item.ArticleCount;
        entity.MarkSentenceCount = item.MarkSentenceCount;
        entity.QuestionCount = item.QuestionCount;
        entity.QuestionCorrectCount = item.QuestionCorrectCount;
        entity.NotesSummary = item.NotesSummary;
        if (item.SentenceDetails?.Count > 0)
        {
            entity.SentenceDetails.Clear();
            foreach (var d in item.SentenceDetails)
            {
                entity.SentenceDetails.Add(new ReadingSentenceDetail
                {
                    ReadingId = entity.Id,
                    SentenceId = d.SentenceId,
                    PlayCount = d.PlayCount,
                    Vocabularies = d.Vocabularies,
                    SentenceContent = d.SentenceContent,
                    Notes = d.Notes
                });
            }
        }
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteReadingAsync(int id, CancellationToken ct = default)
    {
        var entity = await _db.Reading.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.Deleted = true;
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<List<ReadingSentenceDetail>> GetAllReadingSentenceDetailsAsync(int? readingId = null, CancellationToken ct = default)
    {
        var query = _db.ReadingSentenceDetail.AsQueryable();
        if (readingId.HasValue) query = query.Where(x => x.ReadingId == readingId.Value);
        return await query.OrderBy(x => x.Id).ToListAsync(ct);
    }

    public async Task<ReadingSentenceDetail?> GetReadingSentenceDetailByIdAsync(int id, CancellationToken ct = default)
        => await _db.ReadingSentenceDetail.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<int> CreateReadingSentenceDetailAsync(ReadingSentenceDetail item, CancellationToken ct = default)
    {
        _db.ReadingSentenceDetail.Add(item);
        await _db.SaveChangesAsync(ct);
        return item.Id;
    }

    public async Task<bool> UpdateReadingSentenceDetailAsync(int id, ReadingSentenceDetail item, CancellationToken ct = default)
    {
        var entity = await _db.ReadingSentenceDetail.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        entity.ReadingId = item.ReadingId;
        entity.SentenceId = item.SentenceId;
        entity.PlayCount = item.PlayCount;
        entity.Vocabularies = item.Vocabularies;
        entity.SentenceContent = item.SentenceContent;
        entity.Notes = item.Notes;
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteReadingSentenceDetailAsync(int id, CancellationToken ct = default)
    {
        var entity = await _db.ReadingSentenceDetail.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (entity == null) return false;
        _db.ReadingSentenceDetail.Remove(entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}
