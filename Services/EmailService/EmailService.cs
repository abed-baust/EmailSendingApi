using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SimpleEmailAPI.DTOs;

namespace SimpleEmailAPI.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void SendEmail(EmailDtos emailDtos)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(emailDtos.To));

            email.Subject = emailDtos.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = emailDtos.Body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(
                _config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value
                );
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
