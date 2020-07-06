using KnowledgeBase.Infrastructure.Messaging.TestDetails;
using KnowledgeBase.Infrastructure.Messaging.Tests;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Interfaces
{
    public interface ITestService
    {
        Task<GetTestDetailsResponse> GetTestDetailsByUserId(GetTestDetailsRequest getTestDetailsRequest);
        Task<GetTestDetailsByUserExternalIdResponse> GetTestDetailsByUserExternalId(GetTestDetailsByUserExternalIdRequest getTestDetailsByUserExternalIdRequest);
        Task<GetTestResultsResponse> GetTestResults(GetTestResultsRequest getTestResultsRequest);
        Task<PutMarkAnswerResponse> PutMarkAswer(PutMarkAnswerRequest putMarkAnswerRequest);
        Task<PutMarkTestFinishResponse> PutMarkTestFinish(PutMarkTestFinishRequest putMarkTestFinishRequest);
        Task<PutGenerateTestResponse> PutGenerateTests(PutGenerateTestRequest generateTestRequest);
    }
}
