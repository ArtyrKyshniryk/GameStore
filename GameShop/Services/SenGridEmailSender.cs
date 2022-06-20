using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GameShop.Services
{
    public class SenGridEmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
       // private readonly ILogger logger;
        public SenGridEmailSender(IConfiguration configuration)//, ILogger logger)
        {
            this.configuration = configuration;
         //   this.logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = configuration["SenGridApiKey"];
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress("k.artyr2005@gmail.com", "Artyr"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);

            //var responce = await client.SendEmailAsync(message);
            //if(responce.IsSuccessStatusCode)
            //{
            //    logger.LogInformation("Email Send");
            //}
            //else
            //{
            //    logger.LogInformation("error");
            //}
        }
    }
}
