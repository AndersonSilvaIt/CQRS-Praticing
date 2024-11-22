using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Application.Members.Notifications
{
    public class MemberCreatedEmailHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedEmailHandler> _logger;

        public MemberCreatedEmailHandler(ILogger<MemberCreatedEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            // send a confirmation email.
            _logger.LogInformation($"Confirmation email sent for: {notification.Member.LastName} ");

            // lógica para enviar email

            return Task.CompletedTask;
        }
    }
}