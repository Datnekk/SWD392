using be.Data.Models.enums;

namespace be.Dtos.Question;

public class QuestionReadDTO
{
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public required QuestionType QuestionType { get; set; } 
    public string? Options { get; set; } 
    public required string CorrectAnswer { get; set; }
}