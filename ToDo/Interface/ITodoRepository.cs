using ToDo.DTOs.Todo;

namespace ToDo.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<TodoResponseDto>> GetAllAsync();

    Task<TodoResponseDto?> GetByIdAsync(int id);

    Task<TodoResponseDto> CreateAsync(CreateTodoDto dto);

    Task<TodoResponseDto?> UpdateAsync(int id, UpdateTodoDto dto);

    Task DeleteAsync(int id);
}
