using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Application.Members.Notifications
{
    public class MemberCreatedSMSHandler : INotificationHandler<MemberCreatedNotification>
    {
        private readonly ILogger<MemberCreatedSMSHandler> _logger;

        public MemberCreatedSMSHandler(ILogger<MemberCreatedSMSHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
        {
            // send a confirmation email.
            _logger.LogInformation($"Confirmation SMS sent for: {notification.Member.LastName} ");

            // lógica para enviar SMS

            return Task.CompletedTask;
        }
    }
}
