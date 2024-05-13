using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VentasAPI.Models;
using VentasAPI.Services;
using VentasAPI.Interfaces;

namespace VentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        private readonly IVentasService _ventasService;

        public VentasController(IVentasService ventasService)
        {
            _ventasService = ventasService;
        }

        [HttpPost]
        public async Task<IActionResult> RecibirVenta([FromBody] object json)
        {
            await _ventasService.RecibirVenta(json);
            return Ok();
        }

    }
}
