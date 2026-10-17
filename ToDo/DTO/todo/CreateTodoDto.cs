
using System.ComponentModel.DataAnnotations;

namespace ToDo.DTOs.Todo;

public class CreateTodoDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(50, ErrorMessage = "titlte is a maximum of 50 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(300, ErrorMessage = "description is a maximum of 300 characters")]
    public string? Description { get; set; }
}
