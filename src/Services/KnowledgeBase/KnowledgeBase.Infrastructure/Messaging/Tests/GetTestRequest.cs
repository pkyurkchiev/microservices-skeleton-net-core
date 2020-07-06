using System;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class GetTestRequest : GuidIdRequest
    {
        public GetTestRequest(Guid testId) : base(testId) { }
    }
}
