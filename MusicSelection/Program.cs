using Application.Services;
using DataBase;
using DataBase.Repositories;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MusicSelectionDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MusicSelectionDbContext)));
});

builder.Services.AddScoped<ISongsService, SongsService>();
builder.Services.AddScoped<ISongsRepository, SongsRepository>();

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