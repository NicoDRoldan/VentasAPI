using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;
using VentasAPI.Models;
using VentasAPI.Interfaces;

namespace VentasAPI.Services
{
    public class PedidoActualesService : IPedidoActualesService
    {
        private readonly MVCVentasContext _context;

        public PedidoActualesService(MVCVentasContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetvMPedidosActuales()
        {
            return await _context.vMPedidosActuales.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetVMPedidoActual(string numVenta, 
            string numSucursal, string codComprobante)
        {
            var vMPedidoActual = await _context.vMPedidosActuales
                .Where(p => p.NumVenta == numVenta
                    && p.NumSucursal == numSucursal
                    && p.CodComprobante == codComprobante)
                .ToListAsync();

            return vMPedidoActual;
        }

        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetPedidosActuales()
        {
            var pedidosActuales = await _context.vMPedidosActuales
                .Where(p => p.FechaExpiracion >= DateTime.Now)
                .ToListAsync();

            return pedidosActuales;
        }

        public async Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup()
        {
            var order = await _context.vMPedidosActuales
                .Include(a => a.Articulo)
                .Where(p => p.FechaExpiracion >= DateTime.Now)
                .GroupBy(o => new { o.NumPedido, o.Retira })
                .Select(o => new VMOrderGroup
                {
                    NumPedido = o.Key.NumPedido,
                    Retira = o.Key.Retira,
                    DetallePedidos = o.ToList()
                })
                .OrderBy(o => o.NumPedido)
                .ToListAsync();

            return order;
        }

        public async Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup(int numPedido)
        {
            var order = await _context.vMPedidosActuales
                .Include(a => a.Articulo)
                .Where(p => p.FechaExpiracion >= DateTime.Now
                    && p.NumPedido == numPedido)
                .GroupBy(o => new { o.NumPedido, o.Retira })
                .Select(o => new VMOrderGroup
                {
                    NumPedido = o.Key.NumPedido,
                    Retira = o.Key.Retira,
                    DetallePedidos = o.ToList()
                })
                .OrderBy(o => o.NumPedido)
                .ToListAsync();

            return order;
        }
    }
}
