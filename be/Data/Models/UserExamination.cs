namespace be.Data.Models;

public class UserExamination
{
    public int User_id { get; set; }
    public User User { get; set; }
    public int Exam_id { get; set; }
    public Examination Examination { get; set; }
}