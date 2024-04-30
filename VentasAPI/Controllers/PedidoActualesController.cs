using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasAPI.Data;
using VentasAPI.Models;
using VentasAPI.Services;
using VentasAPI.Interfaces;

namespace VentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoActualesController : ControllerBase
    {
        private readonly IPedidoActualesService _iPedidoActualesService;

        public PedidoActualesController(IPedidoActualesService iPedidoActualesService)
        {
            _iPedidoActualesService = iPedidoActualesService;
        }

        [HttpGet("AllRegister")]
        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetvMPedidosActuales()
        {
            return await _iPedidoActualesService.GetvMPedidosActuales();
        }

        [HttpGet("{numVenta}/{numSucursal}/{codComprobante}")]
        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetVMPedidoActual(string numVenta, 
            string numSucursal, string codComprobante)
        {
            var vMPedidoActual = await _iPedidoActualesService.GetVMPedidoActual(numVenta, 
            numSucursal, codComprobante);

            if (vMPedidoActual == null)
            {
                return NotFound();
            }

            return vMPedidoActual;
        }

        [HttpGet("PedidosActuales")]
        public async Task<ActionResult<IEnumerable<VMPedidoActual>>> GetPedidosActuales()
        {
            return await _iPedidoActualesService.GetPedidosActuales();
        }

        [HttpGet("OrderGroup")]
        public async Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup()
        {
            return await _iPedidoActualesService.GetOrderGroup();
        }

        [HttpGet("OrderGroup/{numPedido}")]
        public async Task<ActionResult<IEnumerable<VMOrderGroup>>> GetOrderGroup(int numPedido)
        {
            return await _iPedidoActualesService.GetOrderGroup(numPedido);
        }
    }
}
