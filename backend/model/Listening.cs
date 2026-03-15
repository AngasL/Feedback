namespace Feedback.model;

public class Listening
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int StudentId { get; set; }
    public int? SentenceType { get; set; }
    public string ArticleTitle { get; set; } = string.Empty;
    public int Screening { get; set; }
    public int Total { get; set; }
    public int ArticleCount { get; set; }
    public int MarkSentenceCount { get; set; }
    public int? QuestionCount { get; set; }
    public int? QuestionCorrectCount { get; set; }
    public string NotesSummary { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Deleted { get; set; }

    public ICollection<ListeningSentenceDetail> SentenceDetails { get; set; } = new List<ListeningSentenceDetail>();
}
