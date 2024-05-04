using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VentasAPI.Models;

namespace VentasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        [HttpPost]
        public IActionResult RecibirVenta([FromBody] object json)
        {
            VMVenta vMVenta = JsonConvert.DeserializeObject<VMVenta>(json.ToString());

            string jsonString = json.ToString();
            Console.WriteLine(jsonString); // Imprime el JSON en la consola
            return Ok();
        }
    }
}
