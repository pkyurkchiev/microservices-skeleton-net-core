using System;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class PutMarkAnswerRequest : ServiceRequestBase
    {
        public Guid TestId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public PutMarkAnswerRequest(Guid testId, Guid questionId, Guid answerId)
        {
            TestId = testId;
            QuestionId = questionId;
            AnswerId = answerId;
        }
    }
}
