using Microsoft.AspNetCore.Mvc;
using VentasAPI.Models;

namespace VentasAPI.Interfaces
{
    public interface IVentasService
    {
        Task<IActionResult> CrearVenta([FromBody] VMVenta Venta);
    }
}
