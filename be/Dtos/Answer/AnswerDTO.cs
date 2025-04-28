namespace be.Dtos.Answer;

public class AnswerDTO
{
    public int Answer_id { get; set; }
    public int Question_id { get; set; }
    public string Answer_text { get; set; }
    public bool Is_Correct { get; set; }
}