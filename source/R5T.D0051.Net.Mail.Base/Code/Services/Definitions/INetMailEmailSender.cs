using System;
using System.Net.Mail;

using R5T.T0064;


namespace R5T.D0051.Net.Mail
{
    /// <summary>
    /// Service for sending <see cref="MailMessage"/> emails.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface INetMailEmailSender : IEmailSender<MailMessage>, IServiceDefinition
    {
    }
}
