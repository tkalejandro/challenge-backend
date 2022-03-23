using Microsoft.EntityFrameworkCore;
using authapp_react_net.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// MY USER CONTEXT
builder.Services.AddDbContext<UserSchemaContext>(opt =>
    opt.UseInMemoryDatabase("Users"));


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
