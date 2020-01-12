using KnowledgeBase.ApplicationServices.Messaging.TestDetails;
using KnowledgeBase.ApplicationServices.Messaging.Tests;
using System.Threading.Tasks;

namespace KnowledgeBase.ApplicationServices.Interfaces
{
    public interface ITestService
    {
        Task<GetTestDetailsResponse> GetTestDetailsByUserId(GetTestDetailsRequest getTestDetailsRequest);
        Task<GetTestDetailsByUserExternalIdResponse> GetTestDetailsByUserExternalId(GetTestDetailsByUserExternalIdRequest getTestDetailsByUserExternalIdRequest);
        Task<PutMarkAnswerResponse> PutMarkAswer(PutMarkAnswerRequest putMarkAnswerRequest);
        Task<PutGenerateTestResponse> PutGenerateTests(PutGenerateTestRequest generateTestRequest);
    }
}
