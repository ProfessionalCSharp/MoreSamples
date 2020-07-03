using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace RolesSample.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderOptions _options;
        public EmailSender(IOptions<EmailSenderOptions> options)
        {
            _options = options.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var sendGridOptions = new SendGridClientOptions 
            {
                 ApiKey = _options.ApiKey
            };
            var emailClient = new SendGridClient(sendGridOptions);
            var message = new SendGridMessage
            {
                From = new EmailAddress("authentication@sample.com"),
                Subject = subject,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);
          
            return emailClient.SendEmailAsync(message);
        }
    }
}
