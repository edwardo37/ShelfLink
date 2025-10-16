using Microsoft.EntityFrameworkCore;
using ShelfLink.Models;
using ShelfLink.Repositories;
using ShelfLink.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShelfLinkDbContext>(options =>
    options.UseSqlServer(Environment.GetEnvironmentVariable("SqlServerConnection"))
);

builder.Services.AddScoped(typeof(IShelfLinkRepository<>), typeof(ShelfLinkRepoEfImpl<>));

builder.Services.AddScoped<TitleService>();

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
