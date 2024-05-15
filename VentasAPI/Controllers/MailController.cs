﻿using MailKit.Security;
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
        private readonly IConfiguration _config;

        public MailController(IMailService mailService, IConfiguration config)
        {
            _mailService = mailService;
            _config = config;
        }

        [HttpPost]
        [Route("SendMail")]
        public async Task<IActionResult> SendEmail([FromForm] string emailTo, [FromForm] string client, [FromForm] string emailBody, [FromForm] IFormFile file)
        {
            string emailPass = _config["PasswordMail"];
            string emailFrom = _config["UserNameMail"];
            try
            {
                await _mailService.SendEmail(emailFrom, emailTo, client, emailBody, emailPass, file);
                return Ok("Se envió el corre correspondiente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
