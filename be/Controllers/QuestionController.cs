using AutoMapper;
using be.Repositories;
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

    // [HttpGet]
    // public async Task<IActionResult> GetAll(CancellationToken cancellationToken){
        
    // }
}