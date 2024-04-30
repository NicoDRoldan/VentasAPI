using Microsoft.AspNetCore.Mvc;
using VentasAPI.Models;

namespace VentasAPI.Interfaces
{
    public interface IPedidoActualesService
    {
        Task<ActionResult<IEnumerable<VMPedidoActual>>> GetvMPedidosActuales();

        Task<ActionResult<IEnumerable<VMPedidoActual>>> GetVMPedidoActual(string numVenta,
            string numSucursal, string codComprobante);

        Task<ActionResult<IEnumerable<VMPedidoActual>>> GetPedidosActuales();

        Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup();

        Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup(int numPedido);
    }
}
