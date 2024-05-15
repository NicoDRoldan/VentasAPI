using MimeKit;
using VentasAPI.Interfaces;
using VentasAPI.Models;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace VentasAPI.Services
{
    public class MailService : IMailService
    {

        public async Task SendEmail([FromForm] string emailFrom, [FromForm] string emailTo, [FromForm] string emailBody, [FromForm] string emailPass, [FromForm] IFormFile file )
        {
            string servidor = "smtp-mail.outlook.com";
            int puerto = 587;

            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Prueba", emailFrom));
                emailMessage.To.Add(new MailboxAddress("Destino", emailTo));
                emailMessage.Subject = "Prueba Api .Net";

                var multipart = new Multipart("mixed");

                var textPart = new TextPart("plain")
                {
                    Text = emailBody
                };
                multipart.Add(textPart);

                // Adjuntar el archivo al mensaje de correo
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        var attachment = new MimePart("application/pdf")
                        {
                            Content = new MimeContent(memoryStream),
                            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                            ContentTransferEncoding = ContentEncoding.Base64,
                            FileName = file.FileName
                        };

                        multipart.Add(attachment);

                        emailMessage.Body = multipart;

                        using (var smtpClient = new SmtpClient())
                        {
                            smtpClient.CheckCertificateRevocation = false;
                            await smtpClient.ConnectAsync(servidor, puerto, SecureSocketOptions.StartTls);
                            await smtpClient.AuthenticateAsync(emailFrom, emailPass);
                            await smtpClient.SendAsync(emailMessage);
                            await smtpClient.DisconnectAsync(true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
