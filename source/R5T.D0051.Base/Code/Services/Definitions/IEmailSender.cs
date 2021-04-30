using System;
using System.Threading.Tasks;


namespace R5T.D0051
{
    /// <summary>
    /// Service for sending emails, generically typed for the email messsage representation class.
    /// </summary>
    /// <remarks>
    /// Sending only.
    /// </remarks>
    public interface IEmailSender<TEmailMessage>
    {
        Task Send(TEmailMessage emailMessage);
    }
}
