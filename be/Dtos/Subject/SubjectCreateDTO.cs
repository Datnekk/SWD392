using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace be.Dtos.Subject
{
    public class SubjectCreateDTO
    {
        [Required]
        [MaxLength(255, ErrorMessage = "Subject code cannot exceed 255 characters.")]
        public string Subject_code { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Subject name cannot exceed 255 characters.")]
        public string Subject_name { get; set; }
    }
}