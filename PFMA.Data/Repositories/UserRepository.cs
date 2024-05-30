using Microsoft.EntityFrameworkCore;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;

namespace PFMA.Data.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<int> AddUserAsync(User user)
    {
        if (await GetUserByIdAsync(user.Id) != null) 
            throw new Exception("User already exists");
        
        context.Users!.Add(user);
        
        return await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync() => await context.Users!.ToListAsync();

    public async Task<User?> GetUserByIdAsync(Guid id) => await context.Users!.FindAsync(id);
    public async Task<User?> GetUserByEmailAsync(string email) => await context.Users!.FirstOrDefaultAsync(u => u.Email == email);

    public async Task UpdateUserAsync(User user)
    {
        context.Users!.Update(user);

        await context.SaveChangesAsync();
    }
}