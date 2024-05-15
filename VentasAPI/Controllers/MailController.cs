using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using VentasAPI.Interfaces;
using VentasAPI.Models;
using MailKit.Net.Smtp;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace VentasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public async Task<IActionResult> SendEmail([FromForm] string emailFrom, [FromForm] string emailTo, [FromForm] string emailBody, [FromForm] string emailPass,[FromForm] IFormFile file)
        {
            try
            {
                await _mailService.SendEmail(emailFrom, emailTo, emailBody, emailPass, file);
                return Ok("Se envió el corre correspondiente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
