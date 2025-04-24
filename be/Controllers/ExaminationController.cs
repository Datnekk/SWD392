using AutoMapper;
using be.Data.Models;
using be.Dtos.Examination;
using be.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [ApiController]
    [Route("api/examinations")]
    public class ExaminationController : ControllerBase
    {
        private readonly ILogger<ExaminationController> _logger;
        private readonly IMapper _mapper;
        private readonly IExaminationRepository _examinationRepository;
        public ExaminationController(ILogger<ExaminationController> logger, IMapper mapper, IExaminationRepository examinationRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _examinationRepository = examinationRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var examinations = await _examinationRepository.GetAsync(cancellationToken);
                return Ok(_mapper.Map<IEnumerable<ExaminationDTO>>(examinations));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all examinations");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var exam = await _examinationRepository.GetByIdAsync(id, cancellationToken);
                if (exam == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<ExaminationDTO>(exam));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting examination");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromBody] ExaminationDTO examDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                

                var exam = _mapper.Map<Examination>(examDto);
                await _examinationRepository.AddAsync(exam, cancellationToken);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = exam.Exam_id }, examDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating examination");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExaminationDTO examDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                return BadRequest(ModelState);

                var existingExam = await _examinationRepository.GetByIdAsync(id, cancellationToken);
                if (existingExam == null)
                    return NotFound();

                _mapper.Map(examDto, existingExam);
                await _examinationRepository.UpdateAsync(existingExam, cancellationToken);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating examination");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var exam = await _examinationRepository.GetByIdAsync(id, cancellationToken);
                if (exam == null)
                    return NotFound();

                await _examinationRepository.DeleteAsync(id, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting examination");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}