using System;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class GetTestResultsRequest : GuidIdRequest
    {
        public GetTestResultsRequest(Guid testId) : base(testId) { }
    }
}
