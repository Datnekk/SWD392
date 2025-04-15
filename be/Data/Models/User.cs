using Microsoft.AspNetCore.Identity;

namespace be.Data.Models;

public class User : IdentityUser<Guid>
{
    public string? Image { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid? CurrentSessionId { get; set; }
    public Session? CurrentSession { get; set; }
    public List<Quiz> CreatedQuizzes { get; set; } = [];
}