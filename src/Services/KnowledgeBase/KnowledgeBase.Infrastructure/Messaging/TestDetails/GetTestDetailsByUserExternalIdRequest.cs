namespace KnowledgeBase.Infrastructure.Messaging.TestDetails
{
    public class GetTestDetailsByUserExternalIdRequest : ServiceRequestBase
    {
        public string UserExternalId { get; set; }

        public GetTestDetailsByUserExternalIdRequest(string userExternalId)
        {
            UserExternalId = userExternalId;
        }
    }
}
