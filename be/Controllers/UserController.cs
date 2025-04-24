using AutoMapper;
using be.Dtos.User;
using be.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserController(ILogger<UserController> logger, IMapper mapper, IUserRepository userRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAsync(cancellationToken);
        var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);
        return Ok(usersDto);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            return NotFound();
        }
        var userDto = _mapper.Map<UserDTO>(user);
        return Ok(userDto);
    }

    [HttpPut("{id:int}/status")]
    [Authorize]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UserUpdateDTO userDto, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            return NotFound("User Not Found!");
        }

        user.Status = userDto.Status;
        var success = await _userRepository.UpdateAsync(user, cancellationToken);

        if (!success)
        {
            return BadRequest("Failed to update user status.");
        }

        return Ok(new { Status = user.Status });
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var deleted = await _userRepository.DeleteAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound("User Not Found!");
        }
        return NoContent();
    }

    [HttpPost("{id:int}/assign-role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRoleAsync([FromRoute] int id, [FromBody] string role, CancellationToken cancellationToken = default)
    {
        var success = await _userRepository.AssignRoleAsync(id, role, cancellationToken);
        if (!success)
        {
            return BadRequest("User Not Found or Role Does Not Exist!");
        }
        return Ok($"User with ID {id} assigned to role {role}");
    }
}