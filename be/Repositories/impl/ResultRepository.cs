using be.Data.Models;

namespace be.Repositories.impl;

public class ResultRepository : IResultRepository
{
    private readonly IRepositoryAsync<Result> _resultRepository;
    public ResultRepository(IRepositoryAsync<Result> resultRepository)
    {
        _resultRepository = resultRepository;
    }
    public async Task AddAsync(Result entity, CancellationToken cancellationToken = default)
    {
        await _resultRepository.AddAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _resultRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Result>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _resultRepository.GetAsync(cancellationToken);
    }

    public async Task<Result> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _resultRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(Result entity, CancellationToken cancellationToken = default)
    {
        await _resultRepository.UpdateAsync(entity, cancellationToken);
    }
}