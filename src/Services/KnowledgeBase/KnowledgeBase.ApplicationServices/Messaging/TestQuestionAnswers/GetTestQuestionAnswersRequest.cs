using System;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class GetTestQuestionAnswersRequest : ServiceRequestBase
    {
        public Guid UserId { get; set; }
    }
}
