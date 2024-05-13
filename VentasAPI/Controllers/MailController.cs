using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
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
        [HttpPost]
        [Route("SendMail")]
        public async Task<IActionResult> SendEmail([FromBody] MailData mailData)
        {
            string servidor = "smtp-mail.outlook.com";
            int puerto = 587;

            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Prueba", mailData.EmailFrom));
                emailMessage.To.Add(new MailboxAddress("Destino", mailData.EmailTo));
                emailMessage.Subject = "Prueba Api .Net";

                BodyBuilder builder = new ();
                builder.TextBody = mailData.EmailBody;
                emailMessage.Body = builder.ToMessageBody();

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.CheckCertificateRevocation = false;
                smtpClient.Connect(servidor, puerto, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(mailData.EmailFrom, mailData.EmailPass);
                smtpClient.Send(emailMessage);
                smtpClient.Disconnect(true);

                return Ok("Email envíado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
