using System;

using R5T.D0051.Net.Mail;

using R5T.T0064;


namespace R5T.D0051.Gmail
{
    [ServiceDefinitionMarker]
    public interface IGmailNetMailSender : INetMailEmailSender, IServiceDefinition
    {
    }
}
