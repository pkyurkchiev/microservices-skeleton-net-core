using KnowledgeBase.ApplicationServices.ViewModels;

namespace KnowledgeBase.ApplicationServices.Messaging.Tests
{
    public class GetTestResponse : ServiceResponseBase
    {
        public TestViewModel Test { get; set; }
    }
}
