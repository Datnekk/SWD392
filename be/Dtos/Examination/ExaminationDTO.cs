namespace be.Dtos.Examination;

public class ExaminationDTO
{
    public int Exam_id { get; set; }
    public int Subject_id { get; set; }
    public string Exam_name { get; set; }
    public string Exam_password { get; set; }
    public int No_of_question { get; set; }
}