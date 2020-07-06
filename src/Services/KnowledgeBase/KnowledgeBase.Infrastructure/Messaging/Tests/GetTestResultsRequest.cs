using System;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class GetTestResultsRequest : GuidIdRequest
    {
        public GetTestResultsRequest(Guid testId) : base(testId) { }
    }
}
