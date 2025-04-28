using be.Data.Models.enums;

namespace be.Data.Models;

public class Question
{
    public int Question_id { get; set; }
    public int Subject_id { get; set; }
    public string Question_text { get; set; }
    public QuestionType? Question_type { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public DateTime Updated_at { get; set; } = DateTime.UtcNow;
    public Subject Subject { get; set; }
    public ICollection<Answer> Answers { get; set; }
}