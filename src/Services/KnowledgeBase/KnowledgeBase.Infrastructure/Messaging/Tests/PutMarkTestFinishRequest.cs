using System;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class PutMarkTestFinishRequest : ServiceRequestBase
    {
        public Guid TestId { get; set; }
        public PutMarkTestFinishRequest(Guid testId)
        {
            TestId = testId;
        }
    }
}
