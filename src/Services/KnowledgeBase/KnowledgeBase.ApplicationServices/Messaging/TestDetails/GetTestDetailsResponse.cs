using KnowledgeBase.ApplicationServices.ViewModels;

namespace KnowledgeBase.ApplicationServices.Messaging.TestDetails
{
    public class GetTestDetailsResponse : ServiceResponseBase
    {
        public TestDetailViewModel TestDetails { get; set; }
    }
}
