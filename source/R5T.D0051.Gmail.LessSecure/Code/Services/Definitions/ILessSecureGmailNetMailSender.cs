using System;

using R5T.T0064;


namespace R5T.D0051.Gmail.LessSecure
{
    [ServiceDefinitionMarker]
    public interface ILessSecureGmailNetMailSender : IGmailNetMailSender, IServiceDefinition
    {
    }
}
