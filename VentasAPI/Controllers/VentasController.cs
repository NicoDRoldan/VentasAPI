using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        [HttpPost]
        public IActionResult RecibirVenta([FromBody] object json)
        {
            return Ok(json);
        }
    }
}
