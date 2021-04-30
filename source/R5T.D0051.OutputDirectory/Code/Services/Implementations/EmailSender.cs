using System;
using System.Net.Mail;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.D0055;


namespace R5T.D0051.OutputDirectory
{
    public class EmailSender : IOutputDirectoryNetMailSender
    {
        private IEmailOutputDirectoryPathProvider EmailOutputDirectoryPathProvider { get; }
        private ILogger Logger { get; }


        public EmailSender(
            IEmailOutputDirectoryPathProvider emailOutputDirectoryPathProvider,
            ILogger<EmailSender> logger)
        {
            this.EmailOutputDirectoryPathProvider = emailOutputDirectoryPathProvider;
            this.Logger = logger;
        }

        public async Task Send(MailMessage emailMessage)
        {
            var emailOutputDirectoryPath = await this.EmailOutputDirectoryPathProvider.GetEmailOutputDirectoryPath();

            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailOutputDirectoryPath;

                    await smtpClient.SendMailAsync(emailMessage);

                    this.Logger.LogInformation("Sent email to output directory.");
                }
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception, "Failed to send email to output directory.");

                throw exception; // Re-throw.
            }
        }
    }
}
