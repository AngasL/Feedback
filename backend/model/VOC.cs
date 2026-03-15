namespace Feedback.model;

public class VOC
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int StudentId { get; set; }
    public int Correct { get; set; }
    public int Screening { get; set; }
    public int Total { get; set; }
    public int SetCount { get; set; }
    public string IncorrectWords { get; set; } = string.Empty;
    public int TimeConsumed { get; set; }
    public bool IsPass { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Deleted { get; set; }
}
