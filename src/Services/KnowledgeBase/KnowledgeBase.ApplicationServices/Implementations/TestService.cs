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
        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("Unit of work");
        }

        public async Task<GetTestResponse> GetById(GetTestRequest getTestRequest)
        {
            GetTestResponse result = new GetTestResponse();

            Test test = await _unitOfWork.GetRepository<ITestRepository>().GetById(getTestRequest.Id);
            result.Test = test.ConvertToViewModel();

            return result;
        }

        public async Task<GenerateTestReponse> PutGenerateTests(GenerateTestRequest generateTestRequest)
        {
            GenerateTestReponse result = new GenerateTestReponse();

            await _unitOfWork.GetRepository<ITestRepository>().GenerateTests();
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
