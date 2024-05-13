using MimeKit;
using VentasAPI.Interfaces;
using VentasAPI.Models;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VentasAPI.Services
{
    //public class MailService : IMailService
    //{
    //    private readonly MailSettings _mailSettings;

    //    public MailService (MailSettings mailSettings)
    //    {
    //        _mailSettings = mailSettings;
    //    }

    //    public async Task<bool> IMailService.SendMailAsync(string body)
    //    {
    //        try
    //        {
    //            var emailMessage = new MimeMessage();

    //            emailMessage.From.Add(MailboxAddress.Parse("kailee.sawayn@ethereal.email"));
    //            emailMessage.To.Add(MailboxAddress.Parse("kailee.sawayn@ethereal.email"));
    //            emailMessage.Subject = "Ejemplo";
    //            emailMessage.Body = new TextPart(TextFormat.Html) { Text = body };

    //            using var smtp = new SmtpClient();
    //            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
    //            smtp.Authenticate("kailee.sawayn@ethereal.email", "g3pngXdx6MDVYb8HZv");
    //            smtp.Send(emailMessage);
    //            smtp.Disconnect(true);

    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {
    //            return (ex.Message);

    //        }
    //    }
    //}
}
