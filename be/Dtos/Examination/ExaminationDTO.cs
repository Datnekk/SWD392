using System.ComponentModel.DataAnnotations;

namespace be.Dtos.Examination;

public class ExaminationDTO
{
    [Required]
    [MaxLength(255, ErrorMessage = "Exam name must be less than 255 characters")]
    public string Exam_name { get; set; }
    [Required]
    public int Subject_id { get; set; }
    [Required]
    [MaxLength(255, ErrorMessage = "Exam password must be less than 255 characters")]
    public string Exam_password { get; set; }
    [Required]
    [Range(1, 60, ErrorMessage = "Number of questions must be between 1 and 60")]
    public int No_of_question { get; set; }
}