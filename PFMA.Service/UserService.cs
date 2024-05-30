using System.Security.Cryptography;
using System.Text;
using PFMA.Common;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;

namespace PFMA.Service;

public class UserService(IUserRepository userRepository)
{
    public async Task Register(User user)
    {
        user.PasswordHash = GenerateHashedPassword(user.PasswordHash);

        await userRepository.AddUserAsync(user);
    }

    public async Task<User?> Login(string email, string password)
    {
        var user = await userRepository.GetUserByEmailAsync(email);

        if (user == null || !user.PasswordHash.Equals(GenerateHashedPassword(password))) return null;

        return user;
    }

    private string GenerateHashedPassword(string password)
    {
        var saltByte = Encoding.UTF8.GetBytes(AuthenticationParameter.Salt);
        
        return Convert.ToBase64String(Rfc2898DeriveBytes.Pbkdf2(password, saltByte, AuthenticationParameter.Iterations,
            HashAlgorithmName.SHA256, AuthenticationParameter.HashByteSize));
    }
}