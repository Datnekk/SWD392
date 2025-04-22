using System.ComponentModel.DataAnnotations;

namespace be.Data.Models;

public class Examination
{
    [Key]
    public int Exam_id { get; set; }
    public int Subject_id { get; set; }
    public string Exam_name { get; set; }
    public string Exam_password { get; set; }
    public int No_of_question { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public Subject Subject { get; set; }
    public ICollection<UserExamination> UserExaminations { get; set; } = [];
    public ICollection<Result> Results { get; set; } = [];
}