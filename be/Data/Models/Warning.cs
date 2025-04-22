using System.ComponentModel.DataAnnotations;
using be.Data.Models.enums;

namespace be.Data.Models;

public class Warning
{
    [Key]
    public int Warning_id { get; set; }
    public int User_id { get; set; }
    public WarningType Warning_type { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public User User { get; set; }
}