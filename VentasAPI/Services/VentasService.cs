using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VentasAPI.Interfaces;
using VentasAPI.Models;

namespace VentasAPI.Services
{
    public class VentasService : IVentasService
    {
        public async Task RecibirVenta([FromBody] object json)
        {
            await System.IO.File.WriteAllTextAsync(@"C:\Repositorio\JsonAPI.json", json.ToString());

            VMVenta vMVenta = JsonConvert.DeserializeObject<VMVenta>(json.ToString());
        }

    }
}
