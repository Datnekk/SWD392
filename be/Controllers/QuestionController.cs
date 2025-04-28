using AutoMapper;
using be.Data.Models;
using be.Dtos.Question;
using be.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionController : ControllerBase
{
    private readonly ILogger<QuestionController> _logger;
    private readonly IMapper _mapper;
    private readonly IQuestionRepository _questionRepository;
    public QuestionController(ILogger<QuestionController> logger, IMapper mapper, IQuestionRepository questionRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken){
        try
        {
            var questions = await _questionRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<QuestionDTO>>(questions));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all questions");
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
            var question = await _questionRepository.GetByIdAsync(id, cancellationToken);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<QuestionDTO>(question));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting question");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] QuestioneCreateDTO questionDto, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = _mapper.Map<Question>(questionDto);

            await _questionRepository.AddAsync(question, cancellationToken);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = question.Question_id }, _mapper.Map<QuestionDTO>(question));
            }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating question");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] QuestioneCreateDTO questionDto, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _questionRepository.GetByIdAsync(id, cancellationToken);

            if (question == null)
                return NotFound();

            _mapper.Map(questionDto, question);

            await _questionRepository.UpdateAsync(question, cancellationToken);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating question");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var question = await _questionRepository.GetByIdAsync(id, cancellationToken);
            if(question == null)
                return NotFound("Question Not Found!");
            await _questionRepository.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting question");
            return StatusCode(500, "Internal server error");
        }
    }
}