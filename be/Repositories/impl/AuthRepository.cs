using AutoMapper;
using be.Data.Models;
using be.Dtos.Auth;
using Microsoft.AspNetCore.Identity;

namespace be.Repositories.impl;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenRepository _tokenRepository;
    private readonly IMapper _mapper;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AuthRepository(UserManager<User> userManager, ITokenRepository tokenRepository, IMapper mapper, SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
        _mapper = mapper;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AuthResponseDTO> LoginAsync(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByNameAsync(loginDTO.UserName!);

        if(user is null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password!)){
            return new AuthResponseDTO{
                IsAuthSuccessful = false,
                ErrorMessage = "Invalid Authentication"
            };
        }
       var tokenDTO = await _tokenRepository.CreateJWTTokenAsync(user, populateExp: true);

       _tokenRepository.SetTokenCookie(tokenDTO, _httpContextAccessor.HttpContext);

       return new AuthResponseDTO{
            IsAuthSuccessful = true,
       };
    }

    public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDTO)
    {
        var user = _mapper.Map<User>(registerDTO);

        user.NormalizedUserName = _userManager.NormalizeName(registerDTO.UserName);

        user.NormalizedEmail = _userManager.NormalizeEmail(registerDTO.Email);
        
        user.SecurityStamp = Guid.NewGuid().ToString();

        var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

        if (!createdUser.Succeeded)
        {
            throw new Exception(string.Join(", ", createdUser.Errors.Select(e => e.Description)));
        }

        var roleResult = await _userManager.AddToRoleAsync(user, "Student");
        
        if (!roleResult.Succeeded)
        {
            await _userManager.DeleteAsync(user);
            
            throw new Exception(string.Join(", ", roleResult.Errors.Select(e => e.Description)));
        }

        var response = _mapper.Map<AuthResponseDTO>(user);
        response.IsAuthSuccessful = true;

        return response;
    }

    public async Task LogoutAsync()
    {
        _tokenRepository.DeleteTokenCookie(_httpContextAccessor.HttpContext);
        await _signInManager.SignOutAsync();
    }
}
