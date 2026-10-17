using Microsoft.AspNetCore.Identity;
using TodoList.Api.Models;

namespace ToDo.Model
{
    public class AppUser : IdentityUser
    {
        public List<Todo> Todos { get; set; } = new List<Todo>();
    }
}
