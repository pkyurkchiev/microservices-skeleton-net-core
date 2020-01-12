using KnowledgeBase.ApplicationServices.ViewModels;

namespace KnowledgeBase.ApplicationServices.Messaging.TestDetails
{
    public class GetTestDetailsByUserExternalIdResponse : ServiceResponseBase
    {
        public TestDetailViewModel TestDetails { get; set; }
    }
}
