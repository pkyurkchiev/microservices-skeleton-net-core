using KnowledgeBase.ApplicationServices.Messaging.Tests;
using System.Threading.Tasks;

namespace KnowledgeBase.ApplicationServices.Interfaces
{
    public interface ITestService
    {
        Task<GetTestQuestionAnswersResponse> GetAll(GetTestQuestionAnswersRequest getTestQuestionAnswersRequest);
        Task<GenerateTestReponse> PutGenerateTests(GenerateTestRequest generateTestRequest);
    }
}
