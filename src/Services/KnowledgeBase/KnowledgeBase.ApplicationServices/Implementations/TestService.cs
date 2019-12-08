using KnowledgeBase.ApplicationServices.Interfaces;
using KnowledgeBase.ApplicationServices.Messaging.Tests;
using KnowledgeBase.ApplicationServices.ModelConversions;
using KnowledgeBase.Data.Entities;
using KnowledgeBase.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeBase.ApplicationServices.Implementations
{
    public class TestService : ApplicationServiceBase, ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            _testRepository = testRepository ?? throw new ArgumentNullException("Test repo");
        }

        public async Task<GetTestResponse> GetById(GetTestRequest getTestRequest)
        {
            GetTestResponse result = new GetTestResponse();

            try
            {
                Test test = await _testRepository.GetById(getTestRequest.Id);
                result.Test = test.ConvertToViewModel();
            }
            catch (Exception ex)
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.StatusDesciption = ex.Message;
            }

            return result;
        }

        public async Task<GenerateTestReponse> PutGenerateTests(GenerateTestRequest generateTestRequest)
        {
            throw new NotImplementedException();
        }
    }
}
