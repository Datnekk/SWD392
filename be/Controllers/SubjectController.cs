using AutoMapper;
using be.Data.Models;
using be.Dtos.Subject;
using be.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers;

[ApiController]
[Route("api/subjects")]
public class SubjectController : ControllerBase
{
    private readonly ILogger<SubjectController> _logger;
    private readonly IMapper _mapper;
    private readonly ISubjectRepository _subjectRepository;
    public SubjectController(ILogger<SubjectController> logger, IMapper mapper, ISubjectRepository subjectRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _subjectRepository = subjectRepository;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var subjects = await _subjectRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<SubjectDTO>>(subjects));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all subjects");
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
            var subject = await _subjectRepository.GetByIdAsync(id, cancellationToken);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SubjectDTO>(subject));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting subject");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromBody] SubjectCreateDTO subjectCreateDto, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subject = _mapper.Map<Subject>(subjectCreateDto);

            await _subjectRepository.AddAsync(subject, cancellationToken);

            var createdSubjectDto = _mapper.Map<SubjectDTO>(subject);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdSubjectDto.Subject_id }, createdSubjectDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating subject");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SubjectCreateDTO subjectCreateDto, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subject = await _subjectRepository.GetByIdAsync(id, cancellationToken);

            if (subject == null)
                return NotFound();

            _mapper.Map(subjectCreateDto, subject);

            await _subjectRepository.UpdateAsync(subject, cancellationToken);

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while updating subject");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var subject = await _subjectRepository.GetByIdAsync(id, cancellationToken);
            if (subject == null)
                return NotFound();

            await _subjectRepository.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while deleting subject");
            return StatusCode(500, "Internal server error");
        }
    }
}