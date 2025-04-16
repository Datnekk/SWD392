using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Result
{
    [Key]
    public Guid Certificate_no { get; set; }
    public Guid Exam_id { get; set; }
    public string Student_name { get; set; }
    public double Grade_obtained { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public Examination Examination { get; set; }
}