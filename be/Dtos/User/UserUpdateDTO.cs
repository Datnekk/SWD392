using System.ComponentModel.DataAnnotations;
using be.Data.Models.enums;

namespace be.Dtos.User;

public class UserUpdateDTO
{
    [Required]
    public Status Status { get; set; }
}