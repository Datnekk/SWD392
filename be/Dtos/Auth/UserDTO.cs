namespace be.Dtos.Auth;

public class UserDTO
{
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public IList<string> Roles { get; set; }
}