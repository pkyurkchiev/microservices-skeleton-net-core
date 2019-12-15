using KnowledgeBase.ApplicationServices.ViewModels;
using System.Collections.Generic;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class GetTestQuestionAnswersResponse : ServiceResponseBase
    {
        public TestQuestionAnswerViewModel TestQuestionAnswers { get; set; }
    }
}
