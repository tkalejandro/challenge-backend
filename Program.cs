using Microsoft.EntityFrameworkCore;
using authapp_react_net.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            "AllowCors",
            builder =>
            {
                builder.AllowAnyOrigin().WithMethods(
                    HttpMethod.Get.Method,
                    HttpMethod.Put.Method,
                    HttpMethod.Post.Method,
                    HttpMethod.Delete.Method).AllowAnyHeader().WithExposedHeaders("CustomHeader");
            });
    });

// MY USER CONTEXT
builder.Services.AddDbContext<UserSchemaContext>(opt =>
    opt.UseInMemoryDatabase("Users"));


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseCors("AllowCors");
app.MapControllers();

app.Run();
