using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.Aalborg;

using R5T.D0053;


namespace R5T.D0051.Gmail.LessSecure
{
    public class EmailSender : ILessSecureGmailNetMailSender
    {
        public const string GmailSmtpServerHostName = "smtp.gmail.com";
        public const int TlsPortNumber = 587;
        

        private IGmailAuthenticationProvider GmailAuthenticationProvider { get; }
        private ILogger Logger { get; }


        public EmailSender(
            IGmailAuthenticationProvider gmailAuthenticationProvider,
            ILogger<EmailSender> logger)
        {
            this.GmailAuthenticationProvider = gmailAuthenticationProvider;
            this.Logger = logger;
        }

        public async Task Send(MailMessage emailMessage)
        {
            var authentication = await this.GmailAuthenticationProvider.GetGmailAuthentication();

            var credential = authentication.GetNetworkCredential();

            try
            {
                using (var smtpClient = new SmtpClient()
                {
                    Host = EmailSender.GmailSmtpServerHostName,
                    Port = EmailSender.TlsPortNumber,
                    Credentials = credential,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                })
                {
                    await smtpClient.SendMailAsync(emailMessage);

                    this.Logger.LogInformation("Send email.");
                }
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception, "Failed to send email.");

                throw exception; // Re-throw.
            }
        }
    }
}
