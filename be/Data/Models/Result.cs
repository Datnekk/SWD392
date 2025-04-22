using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Result
{
    [Key]
    public int Result_id { get; set; }
    public int User_id { get; set; }
    public int Exam_id { get; set; }
    public double Grade { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public User User { get; set; }
    public Examination Examination { get; set; }
}