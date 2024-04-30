using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;
using VentasAPI.Interfaces;
using VentasAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MVCVentasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCVentasContext")
    ?? throw new InvalidOperationException("Connection stringn 'MVCVentasContext not found.")));

builder.Services.AddScoped<IPedidoActualesService, PedidoActualesService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
