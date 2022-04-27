using System;

using R5T.D0051.Net.Mail;

using R5T.T0064;


namespace R5T.D0051.OutputDirectory
{
    [ServiceDefinitionMarker]
    public interface IOutputDirectoryNetMailSender : INetMailEmailSender, IServiceDefinition
    {
    }
}
