using Microsoft.AspNetCore.Mvc;
using VentasAPI.Models;

namespace VentasAPI.Interfaces
{
    public interface IMailService
    {
        Task SendEmail([FromForm] string emailFrom, [FromForm] string emailTo, [FromForm] string client, 
            [FromForm] string emailBody, [FromForm] string emailPass, [FromForm] IFormFile file);
    }
}
