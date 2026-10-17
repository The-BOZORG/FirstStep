using Microsoft.AspNetCore.Identity;
using ToDo.DTOs.Auth;
using ToDo.Model;

namespace ToDo.Repositories;

public interface IAuthRepository
{
    Task<IdentityResult> RegisterAsync(RegisterDto dto);

    Task<AppUser?> LoginAsync(LoginDto dto);
}
