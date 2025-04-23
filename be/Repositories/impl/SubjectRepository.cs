using be.Data.Models;

namespace be.Repositories.impl;

public class SubjectRepository : ISubjectRepository
{
    private readonly IRepositoryAsync<Subject> _subjectRepository;
    public SubjectRepository(IRepositoryAsync<Subject> subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
    public async Task AddAsync(Subject entity, CancellationToken cancellationToken = default)
    {
        await _subjectRepository.AddAsync(entity, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await _subjectRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Subject>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _subjectRepository.GetAsync(cancellationToken);
    }

    public async Task<Subject> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _subjectRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task UpdateAsync(Subject entity, CancellationToken cancellationToken = default)
    {
        await _subjectRepository.UpdateAsync(entity, cancellationToken);
    }
}