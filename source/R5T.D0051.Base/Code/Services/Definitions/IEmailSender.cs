using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0051
{
    /// <summary>
    /// Service for sending emails, generically typed for the email messsage representation class.
    /// </summary>
    /// <remarks>
    /// Sending only.
    /// </remarks>
    [ServiceDefinitionMarker]
    public interface IEmailSender<TEmailMessage> : IServiceDefinition
    {
        Task Send(TEmailMessage emailMessage);
    }
}
