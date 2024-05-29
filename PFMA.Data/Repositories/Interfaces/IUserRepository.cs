using PFMA.Common;
using PFMA.Data.Models;

namespace PFMA.Data.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<int> AddUserAsync(User user);
    public Task<IEnumerable<User>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(Guid id);
    public Task UpdateUserAsync(User user);
}