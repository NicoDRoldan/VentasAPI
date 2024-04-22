using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;
using VentasAPI.Models;

namespace VentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoActualesController : ControllerBase
    {
        private readonly MVCVentasContext _context;

        public PedidoActualesController(MVCVentasContext context)
        {
            _context = context;
        }

        [HttpGet("AllRegister")]
        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetvMPedidosActuales()
        {
            return await _context.vMPedidosActuales.ToListAsync();
        }

        [HttpGet("{numVenta}/{numSucursal}/{codComprobante}")]
        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetVMPedidoActual(string numVenta, string numSucursal, string codComprobante)
        {
            var vMPedidoActual = await _context.vMPedidosActuales
                .Where(p => p.NumVenta == numVenta
                    && p.NumSucursal == numSucursal
                    && p.CodComprobante == codComprobante)
                .ToListAsync();

            if (vMPedidoActual == null)
            {
                return NotFound();
            }

            return vMPedidoActual;
        }

        [HttpGet("PedidosActuales")]
        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetPedidosActuales()
        {
            var pedidosActuales = await _context.vMPedidosActuales
                .Where(p => p.FechaExpiracion >= DateTime.Now)
                .ToListAsync();

            return pedidosActuales;
        }

        [HttpGet("OrderGroup")]
        public async Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup()
        {
            var order = await _context.vMPedidosActuales
                .Where(p => p.FechaExpiracion >= DateTime.Now)
                .GroupBy(o => new { o.NumPedido, o.Retira })
                .Select(o => new VMOrderGroup
                {
                    NumPedido = o.Key.NumPedido,
                    Retira = o.Key.Retira
                })
                .OrderBy(o => o.NumPedido)
                .ToListAsync();

            return order;
        }
    }
}
