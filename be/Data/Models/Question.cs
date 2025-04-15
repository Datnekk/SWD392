using System.ComponentModel.DataAnnotations;
using be.Data.Models.enums;

namespace be.Data.Models;

public class Question
{
    [Key]
    public Guid Id { get; set; }
    public required string Text { get; set; }
    public required QuestionType QuestionType { get; set; } 
    public string? Options { get; set; } 
    public required string CorrectAnswer { get; set; }
    public List<Quiz> Quizzes { get; set; } = [];
}