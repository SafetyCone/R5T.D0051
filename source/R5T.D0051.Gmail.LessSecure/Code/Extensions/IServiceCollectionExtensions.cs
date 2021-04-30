using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0053;


namespace R5T.D0051.Gmail.LessSecure
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="EmailSender"/> implementation of <see cref="ILessSecureGmailNetMailSender"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddLessSecureGmailNetMailSender(this IServiceCollection services,
            IServiceAction<IGmailAuthenticationProvider> addGmailAuthenticationProvider)
        {
            services.AddSingleton<ILessSecureGmailNetMailSender, EmailSender>()
                .Run(addGmailAuthenticationProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="EmailSender"/> implementation of <see cref="ILessSecureGmailNetMailSender"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ILessSecureGmailNetMailSender> AddLessSecureGmailNetMailSenderAction(this IServiceCollection services,
            IServiceAction<IGmailAuthenticationProvider> addGmailAuthenticationProvider)
        {
            var serviceAction = ServiceAction.New<ILessSecureGmailNetMailSender>(() => services.AddLessSecureGmailNetMailSender(addGmailAuthenticationProvider));
            return serviceAction;
        }
    }
}
