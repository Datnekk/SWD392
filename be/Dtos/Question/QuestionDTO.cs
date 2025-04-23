using be.Data.Models.enums;

namespace be.Dtos.Question;

public class QuestionDTO
{
    public string Text { get; set; }
    public QuestionType QuestionType { get; set; } 
}