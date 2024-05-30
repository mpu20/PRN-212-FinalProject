using System.Threading.Tasks;
using PFMA.Data.Models;
using PFMA.Data.Repositories.Interfaces;
using PFMA.Service;

namespace PFMA.Interface.ViewModels;

public class RegisterViewModel(IUserRepository userRepository)
{
    private readonly UserService _userService = new(userRepository);

    public async Task Register(User user)
    {
        await _userService.Register(user);
    }
}