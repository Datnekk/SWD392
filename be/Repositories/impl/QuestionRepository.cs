using be.Data.Models;

namespace be.Repositories.impl;

public class QuestionRepository : IQuestionRepository
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionRepository(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task AddAsync(Question entity, CancellationToken cancellationToken = default)
    {
        await _questionRepository.AddAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _questionRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Question>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _questionRepository.GetAsync(cancellationToken);
    }

    public async Task<Question> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _questionRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(Question entity, CancellationToken cancellationToken = default)
    {
        await _questionRepository.UpdateAsync(entity, cancellationToken);
    }
}