namespace be.Data.Models;

public class Answer
{
    public int Answer_id { get; set; }
    public int Question_id { get; set; }
    public string Answer_text { get; set; }
    public bool Is_Correct { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public DateTime Updated_at { get; set; } = DateTime.UtcNow;
    public Question Question { get; set; }
}