using KnowledgeBase.ApplicationServices.ViewModels;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class GetTestResultsResponse : ServiceResponseBase
    {
        public TestDetailResultViewModel TestDetailResults { get; set; }
    }
}
