using KnowledgeBase.ApplicationServices.Messaging.Tests;
using System.Threading.Tasks;

namespace KnowledgeBase.ApplicationServices.Interfaces
{
    public interface ITestService
    {
        Task<GetTestResponse> GetById(GetTestRequest getTestRequest);

        Task<GenerateTestReponse> PutGenerateTests(GenerateTestRequest generateTestRequest);
    }
}
