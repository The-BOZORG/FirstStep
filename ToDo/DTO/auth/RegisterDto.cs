using System.ComponentModel.DataAnnotations;

namespace ToDo.DTOs.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "username is required")]
    [MaxLength(20, ErrorMessage = "username must be more than 20 characters.")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage ="email must be valid")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(4, ErrorMessage = "password must be at least 4 characters.")]
    public string Password { get; set; } = string.Empty;
}