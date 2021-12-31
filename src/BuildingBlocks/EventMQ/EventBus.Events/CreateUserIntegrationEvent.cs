using System;

namespace EventBus.Events
{
    public class CreateUserIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public string FacultyNumber { get; set; }
    }
}
