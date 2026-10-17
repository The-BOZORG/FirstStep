using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using ToDo.Data;
using ToDo.Model;
using ToDo.Repositories;
using ToDo.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<TodoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoConnectionSting")));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


builder.Services.AddControllers();

builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TodoDbContext>();

builder.Services.Configure<IdentityOptions>(opttions =>
{
    opttions.Password.RequireDigit = false;
    opttions.Password.RequireLowercase = false;
    opttions.Password.RequireNonAlphanumeric = false;
    opttions.Password.RequireUppercase = false;
    opttions.Password.RequiredLength = 4; 
    opttions.Password.RequiredUniqueChars = 1;
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
