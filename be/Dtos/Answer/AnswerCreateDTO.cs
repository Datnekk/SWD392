using System.ComponentModel.DataAnnotations;

namespace be.Dtos.Answer;

public class AnswerCreateDTO
{
    [Required]
    public int Question_id { get; set; }
    [Required]
    [MaxLength(5000, ErrorMessage = "Answer text cannot exceed 5000 characters.")]
    public string Answer_text { get; set; }
    [Required]
    public bool Is_Correct { get; set; }
}