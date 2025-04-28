using AutoMapper;
using be.Data.Models;
using be.Dtos.Answer;
using be.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly ILogger<AnswerController> _logger;
    private readonly IMapper _mapper;
    private readonly IAnswerRepository _answerRepository;

    public AnswerController(ILogger<AnswerController> logger, IMapper mapper, IAnswerRepository answerRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _answerRepository = answerRepository;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var answers = await _answerRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<AnswerDTO>>(answers));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all answers");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ActionName(nameof(GetByIdAsync))]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var answer = await _answerRepository.GetByIdAsync(id, cancellationToken);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AnswerDTO>(answer));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting answer");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] AnswerCreateDTO answerDto, CancellationToken cancellationToken)
    {
        try
        {
            var answer = _mapper.Map<Answer>(answerDto);

            await _answerRepository.AddAsync(answer, cancellationToken);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = answer.Answer_id }, _mapper.Map<AnswerDTO>(answer));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating answer");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] AnswerCreateDTO answerDto, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answer = await _answerRepository.GetByIdAsync(id, cancellationToken);

            if (answer == null)
            {
                return NotFound();
            }

            _mapper.Map(answerDto, answer);

            await _answerRepository.UpdateAsync(answer, cancellationToken);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating answer");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var answer = await _answerRepository.GetByIdAsync(id, cancellationToken);

            if (answer == null)
            {
                return NotFound();
            }

            await _answerRepository.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting answer");
            return StatusCode(500, "Internal server error");
        }
    }
}