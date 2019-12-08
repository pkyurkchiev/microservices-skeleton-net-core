using System;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class GetTestRequest : GuidIdRequest
    {
        public GetTestRequest(Guid testId) : base(testId) { }
    }
}
