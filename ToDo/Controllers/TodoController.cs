
using Microsoft.AspNetCore.Mvc;
using ToDo.DTOs.Todo;
using ToDo.Repositories;

namespace ToDo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoRepository todoRepository;

    public TodosController(ITodoRepository _todoRepository)
    {
        this.todoRepository = _todoRepository;
    }

    
    [HttpGet] // GET: api/todos
    public async Task<IActionResult> GetAll()
    {
        var todos = await todoRepository.GetAllAsync();

        return Ok(todos);
    }

    
    [HttpGet("{id:int}")] // GET: api/todos/5
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await todoRepository.GetByIdAsync(id);

        if (todo is null)
            return NotFound();

        return Ok(todo);
    }

    
    [HttpPost] // POST: api/todos
    public async Task<IActionResult> Create(CreateTodoDto dto)
    {
        var todo = await todoRepository.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = todo.Id },
            todo);
    }

    
    [HttpPut("{id:int}")] // PUT: api/todos/5
    public async Task<IActionResult> Update(
        int id,
        UpdateTodoDto dto)
    {
        var todo = await todoRepository.UpdateAsync(id, dto);

        if (todo is null)
            return NotFound();

        return Ok(todo);
    }

    
    [HttpDelete("{id:int}")] // DELETE: api/todos/5   
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await todoRepository.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
