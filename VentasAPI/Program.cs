using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;
using VentasAPI.Interfaces;
using VentasAPI.Services;
using Microsoft.OpenApi.Models;
using VentasAPI.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MVCVentasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCVentasContext")
    ?? throw new InvalidOperationException("Connection stringn 'MVCVentasContext not found.")));

builder.Services.AddScoped<IPedidoActualesService, PedidoActualesService>();
builder.Services.AddScoped<IVentasService, VentasService>();
builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Ventas API",
        Version = "v1",
        Description = "API para MVC Ventas",
        Contact = new OpenApiContact
        {
            Name = "MVC Ventas Email",
            Email = "mvcventasapp@gmail.com",
            Url = new Uri("http://examplemvcventasapp.com/contact"),
        },
    });
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//builder.Services.AddTransient<VentasAPI.Interfaces.IMailService, VentasAPI.Services.MailService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", app =>
    {
        app.AllowAnyOrigin()   
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

builder.Configuration.AddConfiguration(config);

builder.WebHost.UseUrls("https://localhost:7200");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Logger(l => l
        .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error)
        .WriteTo.File("LogsError/Error.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l
        .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information)
        .WriteTo.File("Logs/Log.txt", rollingInterval: RollingInterval.Day))
    .WriteTo.Logger(l => l
        .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Warning)
        .WriteTo.File("LogsWarning/Log.txt", rollingInterval: RollingInterval.Day))
    .CreateLogger();

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
