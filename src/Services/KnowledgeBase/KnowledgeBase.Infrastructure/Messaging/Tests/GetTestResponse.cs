using KnowledgeBase.Infrastructure.ViewModels;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class GetTestResponse : ServiceResponseBase
    {
        public TestDetailViewModel Test { get; set; }
    }
}
