namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class PutGenerateTestRequest : ServiceRequestBase
    {
        public string Description { get; set; }

        public PutGenerateTestRequest(string description)
        {
            Description = description;
        }
    }
}
