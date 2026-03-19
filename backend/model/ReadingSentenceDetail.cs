namespace Feedback.model;

public class ReadingSentenceDetail
{
    public int Id { get; set; }
    public int ReadingId { get; set; }
    public Reading Reading { get; set; } = null!;
    public int SentenceId { get; set; }
    public int PlayCount { get; set; }
    public string Vocabularies { get; set; } = string.Empty;
    public string SentenceContent { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}

