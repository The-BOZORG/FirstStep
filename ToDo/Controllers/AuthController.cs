using Microsoft.AspNetCore.Mvc;
using ToDo.DTOs.Auth;
using ToDo.Repositories;

namespace ToDo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository authRepository;

    public AuthController(IAuthRepository _authRepository)
    {
        this.authRepository = _authRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await authRepository.RegisterAsync(dto);

        if (!result.Succeeded)
            return BadRequest("Register failed");

        return Ok("register success!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await authRepository.LoginAsync(dto);

        if (user is null)
            return Unauthorized("email or password is not correct");          

        return Ok(new
        {
            Message = "login success",
            UserId = user.Id,
            Email = user.Email
        });
    }
}
