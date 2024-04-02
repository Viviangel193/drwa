// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
// // using TodoApi.Data; // Pastikan namespace TodoApi.Data telah diimpor

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();

// // Replace with your connection string. 
// var connectionString = "server=localhost; user=root; password=; database=tokobuah";

// var serverVersion = ServerVersion.AutoDetect(connectionString);

// builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions => dbContextOptions
//     .UseMySql(connectionString, serverVersion)
//     // The following three options help with debugging, but should
//     // be changed or removed for production.
//     .LogTo(Console.WriteLine, LogLevel.Information)
//     .EnableSensitiveDataLogging()
//     .EnableDetailedErrors()
// );

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
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