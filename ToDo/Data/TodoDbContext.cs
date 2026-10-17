using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Model;
using TodoList.Api.Models;

namespace ToDo.Data
{
    public class TodoDbContext : IdentityDbContext<AppUser>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<Todo> Todos { get; set; }


    }   
}
