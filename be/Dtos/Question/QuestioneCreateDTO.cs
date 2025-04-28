using System.ComponentModel.DataAnnotations;
using be.Data.Models.enums;

namespace be.Dtos.Question;

public class QuestioneCreateDTO
{
    [Required]
    public int Subject_id { get; set; }
    [Required]
    [MaxLength(5000, ErrorMessage = "Question text cannot exceed 5000 characters.")]
    [MinLength(1, ErrorMessage = "Question text must be at least 1 character long.")]
    public string Question_text { get; set; }
    [Required]
    public QuestionType Question_type { get; set; }     
}