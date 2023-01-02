using Microsoft.EntityFrameworkCore;
using MuseumApi.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MuseumContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
                      c
                          .SwaggerEndpoint("/swagger/v1/swagger.json",
                          "MuseumApi v1"));
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
