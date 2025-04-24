using be.Dtos.Auth;
using be.Dtos.User;

namespace be.Repositories;

public interface IAuthRepository
{
    Task<AuthResponseDTO> LoginAsync(LoginDTO loginDTO);
    Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDTO);
    Task<UserDTO?> GetCurrentUserAsync();
    Task LogoutAsync();

}