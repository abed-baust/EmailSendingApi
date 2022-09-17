using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SimpleEmailAPI.DTOs;

namespace SimpleEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailservice;

        public EmailController(IEmailService emailService)
        {
            _emailservice = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDtos emailDtos)
        {
            _emailservice.SendEmail(emailDtos);

            return Ok();

        }

    }
}
