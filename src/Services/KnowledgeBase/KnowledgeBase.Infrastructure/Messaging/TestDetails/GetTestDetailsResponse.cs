using KnowledgeBase.Infrastructure.ViewModels;

namespace KnowledgeBase.Infrastructure.Messaging.TestDetails
{
    public class GetTestDetailsResponse : ServiceResponseBase
    {
        public TestDetailViewModel TestDetails { get; set; }
    }
}
