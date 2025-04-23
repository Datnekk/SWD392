using be.Data.Models.enums;
using Microsoft.AspNetCore.Identity;

namespace be.Data.Models;

public class User : IdentityUser<int>
{
    public Status? Status { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<UserExamination> UserExaminations { get; set; }
    public ICollection<Result> Results { get; set; }
    public ICollection<Warning> Warnings { get; set; }
}