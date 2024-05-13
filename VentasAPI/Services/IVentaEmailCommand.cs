using VentasAPI.Models;

namespace VentasAPI.Services
{
    public interface IVentaEmailCommand
    {
        VMVenta Venta { get; }
    }
}
