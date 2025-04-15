
using be.Data.Models;
using be.Dtos.Auth;

namespace be.Repositories
{
    public interface ITokenRepository
    {
        Task<TokenDTO> CreateJWTTokenAsync(User user, bool populateExp);
        Task<TokenDTO> RefreshJWTTokenAsync(TokenDTO tokenDTO);
        void SetTokenCookie(TokenDTO tokenDTO, HttpContext context);
        void DeleteTokenCookie(HttpContext context);
    }
}