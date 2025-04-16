using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Examination
{
    [Key]
    public Guid Exam_id { get; set; }
    public Guid Subject_id { get; set; }
    public string Exam_name { get; set; }
    public string Exam_password { get; set; }
    public int No_of_question { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public DateTime Updated_at { get; set; } = DateTime.UtcNow;
    public Subject Subject { get; set; }
    public ICollection<User> Students { get; set; } = [];
    public ICollection<Result> Results { get; set; } = [];
}