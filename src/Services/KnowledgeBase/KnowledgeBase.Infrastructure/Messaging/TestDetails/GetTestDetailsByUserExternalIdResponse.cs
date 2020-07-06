using KnowledgeBase.Infrastructure.ViewModels;

namespace KnowledgeBase.Infrastructure.Messaging.TestDetails
{
    public class GetTestDetailsByUserExternalIdResponse : ServiceResponseBase
    {
        public TestDetailViewModel TestDetails { get; set; }
    }
}
