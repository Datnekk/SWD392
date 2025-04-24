using be.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace be.Repositories.impl;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    public UserRepository(UserManager<User> userManager)
    {            
        _userManager = userManager;
    }

    public async Task<bool> AssignRoleAsync(int id, string role, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return false;
        }

        var result = await _userManager.AddToRoleAsync(user, role);
        return result.Succeeded;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return false;
        }

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }

    public async Task<IEnumerable<User>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByIdAsync(id.ToString()) ?? throw new KeyNotFoundException($"User with ID {id} not found.");
        return user;
    }

    public async Task<bool> UpdateAsync(User user, CancellationToken cancellationToken = default)
    {
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded;
    }
}