using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Subject
{
  [Key]
  public int Subject_id { get; set; }
  public string Subject_code { get; set; }
  public string Subject_name { get; set; }
  public DateTime Created_at { get; set; } = DateTime.UtcNow;
  public DateTime Updated_at { get; set; } = DateTime.UtcNow;
  public ICollection<Examination> Examinations { get; set; } = [];
  public ICollection<Question> Questions { get; set; } = [];
}