namespace be.Dtos.User;

public class UserDTO
{
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public IList<string> Roles { get; set; }
    public string Status { get; set; }
}