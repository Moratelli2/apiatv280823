using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIatv280823.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIatv280823Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIatv280823Context") ?? throw new InvalidOperationException("Connection string 'APIatv280823Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
