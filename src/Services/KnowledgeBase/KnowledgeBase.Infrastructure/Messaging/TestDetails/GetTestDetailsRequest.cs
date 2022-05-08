using System;

namespace KnowledgeBase.Infrastructure.Messaging.TestDetails
{
    public class GetTestDetailsRequest : ServiceRequestBase
    {
        public Guid TestId { get; set; }

        public GetTestDetailsRequest(Guid testId)
        {
            TestId = testId;
        }
    }
}
