using be.Data.Models;

namespace be.Repositories.impl
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly IRepositoryAsync<Examination> _examinationRepository;
        public ExaminationRepository(IRepositoryAsync<Examination> examinationRepository)
        {
            _examinationRepository = examinationRepository;
        }
        public async Task AddAsync(Examination entity, CancellationToken cancellationToken = default)
        {
            await _examinationRepository.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _examinationRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Examination>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _examinationRepository.GetAsync(cancellationToken);
        }

        public async Task<Examination> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _examinationRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(Examination entity, CancellationToken cancellationToken = default)
        {
            await _examinationRepository.UpdateAsync(entity, cancellationToken);
        }
    }
}