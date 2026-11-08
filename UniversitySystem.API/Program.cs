//using Microsoft.EntityFrameworkCore;
using UniversitySystem.API.Middleware;
using UniversitySystem.Core.Common;
using UniversitySystem.Core.Repository;
using UniversitySystem.Core.Service;
using UniversitySystem.Infra.Common;
using UniversitySystem.Infra.Repository;
using UniversitySystem.Infra.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext,DbContext>();
builder.Services.AddScoped<ICourseRepository,CourseRepository>();
builder.Services.AddScoped<ICourseService,CourseService>();
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
