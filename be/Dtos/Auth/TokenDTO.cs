namespace be.Dtos.Auth;

public class TokenDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime AccessTokenExpiryTime { get; set; }
}