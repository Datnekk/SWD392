using be.Data.Models;

namespace be.Repositories;

public interface IUserRepository
{
    Task<bool> AssignRoleAsync(int id, string role, CancellationToken cancellationToken = default);
    Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAsync(CancellationToken cancellationToken = default);    
    Task<bool> UpdateAsync(User user, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}