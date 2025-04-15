using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Session
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid QuizId { get; set; }
    public required Quiz Quiz { get; set; }
    public List<User> Users { get; set; } = [];
}