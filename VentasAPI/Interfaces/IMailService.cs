using VentasAPI.Models;

namespace VentasAPI.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendMailAsync(MailData mailData);
    }
}
