using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Quiz
{
    [Key]
    public Guid Id { get; set; }
    public Guid CreatorId  { get; set; }
    public required string Title { get; set; }
    public int TimeLimit { get; set; }
    public required User Creator { get; set; }
    public List<Question> Questions { get; set; } = [];
}