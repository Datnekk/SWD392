using be.Data.Models;

namespace be.Repositories.impl;

public class AnswerRepository : IAnswerRepository
{
    private readonly IRepositoryAsync<Answer> _answerRepository;
    public AnswerRepository(IRepositoryAsync<Answer> answerRepository)
    {
        _answerRepository = answerRepository;
    }
    public async Task AddAsync(Answer entity, CancellationToken cancellationToken = default)
    {
        await _answerRepository.AddAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _answerRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Answer>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _answerRepository.GetAsync(cancellationToken);
    }

    public async Task<Answer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _answerRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(Answer entity, CancellationToken cancellationToken = default)
    {
        await _answerRepository.UpdateAsync(entity, cancellationToken);
    }
}