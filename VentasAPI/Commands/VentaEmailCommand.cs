using VentasAPI.Models;
using VentasAPI.Services;

namespace VentasAPI.Commands
{
    public class VentaEmailCommand : IVentaEmailCommand
    {
        public VMVenta Venta { get; private set; }

        public VentaEmailCommand(VMVenta venta)
        {
            Venta = venta;
        }

        public async Task EnviarEmail()
        {

        }
    }
}
