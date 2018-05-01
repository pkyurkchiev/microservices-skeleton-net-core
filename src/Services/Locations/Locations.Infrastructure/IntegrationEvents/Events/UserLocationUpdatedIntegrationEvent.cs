using EventBus.Events;
using Locations.Data.Entities;
using System.Collections.Generic;

namespace Locations.Infrastructure.IntegrationEvents.Events
{
    public class UserLocationUpdatedIntegrationEvent : IntegrationEvent
    {
        public string UserId { get; set; }
        public List<UserLocationDetails> LocationList { get; set; }

        public UserLocationUpdatedIntegrationEvent(string userId, List<UserLocationDetails> locationList)
        {
            UserId = userId;
            LocationList = locationList;
        }
    }
}
