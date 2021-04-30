using System;
using System.Net.Mail;


namespace R5T.D0051.Net.Mail
{
    /// <summary>
    /// Service for sending <see cref="System.Net.Mail.MailMessage"/> emails.
    /// </summary>
    /// <remarks>
    public interface INetMailEmailSender<TEmailMessage> : IEmailSender<MailMessage>
    {
    }
}
