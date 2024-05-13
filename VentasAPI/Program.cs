using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;
using VentasAPI.Interfaces;
using VentasAPI.Services;
using Microsoft.OpenApi.Models;
using VentasAPI.Models;
using MailKit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MVCVentasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCVentasContext")
    ?? throw new InvalidOperationException("Connection stringn 'MVCVentasContext not found.")));

builder.Services.AddScoped<IPedidoActualesService, PedidoActualesService>();
builder.Services.AddScoped<IVentasService, VentasService>();

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
