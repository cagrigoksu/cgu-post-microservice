using PostMicroService.Repositories;
using PostMicroService.Repositories.Interfaces;
using PostMicroService.Services;
using PostMicroService.Services.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using PostMicroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// database config
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("AzureSQLConnection")));

// interfaces
builder.Services.AddScoped<IJobPostService, JobPostService>();
builder.Services.AddScoped<IJobPostRepository, JobPostRepository>();

var app = builder.Build();

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
