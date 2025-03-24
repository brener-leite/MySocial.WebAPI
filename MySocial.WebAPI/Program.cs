using Microsoft.EntityFrameworkCore;
using MySocial.Domain.Interfaces;
using MySocial.Infrastructure.Data;
using MySocial.Infrastructure.Repositories;
using User = MySocial.Application.Features.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

// Handlers
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(User.Commands.CreateUser.CreateUserCommand).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
