using System.ComponentModel.DataAnnotations;
using be.Data.Models.enums;

namespace be.Data.Models;

public class Question
{
    [Key]
    public Guid Question_id { get; set; }
    public Guid Subject_id { get; set; }
    public string Question_text { get; set; }
    public required QuestionType Question_type { get; set; } 
    public required string Correct_answer { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public DateTime Updated_at { get; set; } = DateTime.UtcNow;
    public Subject Subject { get; set; }
}