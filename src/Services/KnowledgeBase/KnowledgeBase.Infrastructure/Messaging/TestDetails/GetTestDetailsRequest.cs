using System;

namespace KnowledgeBase.Infrastructure.Messaging.TestDetails
{
    public class GetTestDetailsRequest : ServiceRequestBase
    {
        public Guid UserId { get; set; }

        public GetTestDetailsRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
