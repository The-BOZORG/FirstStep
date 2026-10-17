
using Microsoft.AspNetCore.Identity;
using ToDo.DTOs.Auth;
using ToDo.Model;

namespace ToDo.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<AppUser> userManager;

    public AuthRepository(UserManager<AppUser> _userManager)
    {
        this.userManager = _userManager;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
    {
        var user = new AppUser
        {
            UserName = dto.UserName,
            Email = dto.Email
        };

        return await userManager.CreateAsync(user, dto.Password);
    }

    public async Task<AppUser?> LoginAsync(LoginDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        if (user is null)
        {
            return null;
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(
            user,
            dto.Password
        );

        if (!isPasswordValid)
        {
            return null;
        }

        return user;
    }
}
