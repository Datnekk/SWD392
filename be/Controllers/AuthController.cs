using be.Dtos.Auth;
using be.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(IAuthRepository authRepository, ITokenRepository tokenRepository)
        {
            _authRepository = authRepository;
            _tokenRepository = tokenRepository;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _authRepository.LoginAsync(loginDTO);

                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _authRepository.RegisterAsync(registerDTO);
                
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                await _authRepository.LogoutAsync();
            
                return Ok("Logged out successfully.");
            }
            catch (Exception ex)
            {    
                return StatusCode(500, $"Error logging out: {ex.Message}");
            }
        }

        [HttpPost("refresh")]
        [Authorize]
        public async Task<IActionResult> RefreshAsync()
        {
            try
            {
                HttpContext.Request.Cookies.TryGetValue("accessToken", out var accessToken);

                HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

                var tokenDTO = new TokenDTO{
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };

                var tokenDtoToReturn = await _tokenRepository.RefreshJWTTokenAsync(tokenDTO);

                _tokenRepository.SetTokenCookie(tokenDtoToReturn, HttpContext);

                return Ok();
            }
            catch (Exception ex)
            {  
                return StatusCode(500, $"Error refresh token: {ex.Message}");
            }
            
        }

    [HttpPost("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            try
            {
                var user = await _authRepository.GetCurrentUserAsync();

                if (user == null)
                {
                    return Unauthorized("No authenticated user found.");
                }

                return Ok(user);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving user: {ex.Message}");
            }
        }
    }
}