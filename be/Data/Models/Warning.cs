namespace be.Data.Models;

public class Warning
{
    public Guid Warning_id { get; set; }
    public Guid User_id { get; set; }
    public string Student_name { get; set; }
    public string Warning_type { get; set; }
    public DateTime Created_at { get; set; } = DateTime.UtcNow;
    public User User { get; set; }
}