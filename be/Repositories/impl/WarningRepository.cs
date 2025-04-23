using be.Data.Models;

namespace be.Repositories.impl;

public class WarningRepository : IWarningRepository
{
    private readonly IRepositoryAsync<Warning> _warningRepository;
    public WarningRepository(IRepositoryAsync<Warning> warningRepository)
    {
        _warningRepository = warningRepository;
    }
    public async Task AddAsync(Warning entity, CancellationToken cancellationToken = default)
    {
        await _warningRepository.AddAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _warningRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Warning>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _warningRepository.GetAsync(cancellationToken);
    }

    public async Task<Warning> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _warningRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(Warning entity, CancellationToken cancellationToken = default)
    {
        await _warningRepository.UpdateAsync(entity, cancellationToken);
    }
}