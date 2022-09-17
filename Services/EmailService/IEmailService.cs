using SimpleEmailAPI.DTOs;

namespace SimpleEmailAPI.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDtos emailDtos);
    }
}
