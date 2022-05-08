using EventBus.Abstractions;
using EventBus.Events;
using KnowledgeBase.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.API.Infrastructure.IntegrationEvents.EventHandling
{
    public class CreateUserIntegrationEventHandler : IIntegrationEventHandler<CreateUserIntegrationEvent>
    {
        private readonly IUserService _service;
        private readonly ILogger<CreateUserIntegrationEventHandler> _logger;
        public CreateUserIntegrationEventHandler(IUserService service, ILogger<CreateUserIntegrationEventHandler> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(CreateUserIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation($"----- Handling integration event: {@event.Id} at {Program.AppName} - ({@event})");

                //await _service.CancelConversionsAsync(@event.ProgressUrls);
            }
        }
    }
}
