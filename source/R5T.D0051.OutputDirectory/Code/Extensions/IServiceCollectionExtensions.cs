using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0055;


namespace R5T.D0051.OutputDirectory
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="EmailSender"/> implementation of <see cref="IOutputDirectoryNetMailSender"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddOutputDirectoryNetMailSender(this IServiceCollection services,
            IServiceAction<IEmailOutputDirectoryPathProvider> emailOutputDirectoryPathProviderAction)
        {
            services.AddSingleton<IOutputDirectoryNetMailSender, EmailSender>()
                .Run(emailOutputDirectoryPathProviderAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="EmailSender"/> implementation of <see cref="IOutputDirectoryNetMailSender"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IOutputDirectoryNetMailSender> AddOutputDirectoryNetMailSenderAction(this IServiceCollection services,
            IServiceAction<IEmailOutputDirectoryPathProvider> emailOutputDirectoryPathProviderAction)
        {
            var serviceAction = ServiceAction.New<IOutputDirectoryNetMailSender>(() => services.AddOutputDirectoryNetMailSender(
                emailOutputDirectoryPathProviderAction));

            return serviceAction;
        }
    }
}
