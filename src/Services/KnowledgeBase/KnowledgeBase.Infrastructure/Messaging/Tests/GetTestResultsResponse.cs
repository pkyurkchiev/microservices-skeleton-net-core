using KnowledgeBase.Infrastructure.ViewModels;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class GetTestResultsResponse : ServiceResponseBase
    {
        public TestDetailResultViewModel TestDetailResults { get; set; }
    }
}
