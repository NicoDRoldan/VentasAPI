using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MVCVentasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCVentasContext")
    ?? throw new InvalidOperationException("Connection stringn 'MVCVentasContext not found.")));

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
