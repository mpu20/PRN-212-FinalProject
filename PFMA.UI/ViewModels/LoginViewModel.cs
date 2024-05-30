using System.Threading.Tasks;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;
using PFMA.Service;

namespace PFMA.Interface.ViewModels;

public class LoginViewModel(IUserRepository userRepository)
{
    private readonly UserService _userService = new(userRepository);

    public async Task<User?> Login(string email, string password)
    {
        return await _userService.Login(email, password);
    }
}