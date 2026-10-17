using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ToDo.Data;
using ToDo.DTOs.Todo;
using ToDo.Repositories;
using TodoList.Api.Models;

namespace ToDo.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext context;

        public TodoRepository(TodoDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<TodoResponseDto>> GetAllAsync()
        {
            return await context.Todos
                .AsNoTracking()
                .Select(todo => new TodoResponseDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    IsCompleted = todo.IsCompleted,
                    CreatedAt = todo.CreatedAt,
                })
                .ToListAsync();
        }

        public async Task<TodoResponseDto?> GetByIdAsync(int id)
        {
            return await context.Todos
                .AsNoTracking()
                .Where(todo => todo.Id == id)
                .Select(todo => new TodoResponseDto
                {
                    Id = todo.Id,
                    Title = todo.Title,
                    Description = todo.Description,
                    IsCompleted = todo.IsCompleted,
                    CreatedAt = todo.CreatedAt,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TodoResponseDto> CreateAsync(CreateTodoDto dto)
        {
            var todo = new Todo
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            context.Todos.Add(todo);
            await context.SaveChangesAsync();

            return new TodoResponseDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
            };
        }

        public async Task<TodoResponseDto?> UpdateAsync(int id, UpdateTodoDto dto)
        {
            var todo = await context.Todos.FindAsync(id);

            if (todo is null)
                return null;

            todo.Title = dto.Title;
            todo.Description = dto.Description;
            todo.IsCompleted = dto.IsCompleted;

            await context.SaveChangesAsync();

            return new TodoResponseDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await context.Todos.FindAsync(id);

            if (todo is null)
                return false;

            context.Todos.Remove(todo);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
