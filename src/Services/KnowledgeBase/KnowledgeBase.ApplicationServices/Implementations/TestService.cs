using KnowledgeBase.ApplicationServices.Interfaces;
using KnowledgeBase.ApplicationServices.Messaging.TestDetails;
using KnowledgeBase.ApplicationServices.Messaging.Tests;
using KnowledgeBase.ApplicationServices.ModelConversions;
using KnowledgeBase.Data.Entities;
using KnowledgeBase.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeBase.ApplicationServices.Implementations
{
    public class TestService : ApplicationServiceBase, ITestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("UnitOfWork");
        }

        public async Task<GetTestDetailsResponse> GetTestDetailsByUserId(GetTestDetailsRequest getTestDetailsRequest)
        {
            GetTestDetailsResponse result = new GetTestDetailsResponse();
            IEnumerable<TestDetail> tests = await _unitOfWork.GetRepository<ITestDetailRepository>().GetByUserId(getTestDetailsRequest.UserId);
            result.TestDetails = tests.ConvertToViewModel();

            return result;
        }

        public async Task<GetTestDetailsByUserExternalIdResponse> GetTestDetailsByUserExternalId(GetTestDetailsByUserExternalIdRequest getTestDetailsByUserExternalIdRequest)
        {
            GetTestDetailsByUserExternalIdResponse result = new GetTestDetailsByUserExternalIdResponse();
            IEnumerable<TestDetail> tests = await _unitOfWork.GetRepository<ITestDetailRepository>().GetByUserExternalId(getTestDetailsByUserExternalIdRequest.UserExternalId);
            result.TestDetails = tests.ConvertToViewModel();

            return result;
        }

        public async Task<PutMarkAnswerResponse> PutMarkAswer(PutMarkAnswerRequest putMarkAnswerRequest)
        {
            PutMarkAnswerResponse result = new PutMarkAnswerResponse();
            await _unitOfWork.GetRepository<ITestDetailRepository>().MarkAnswer(putMarkAnswerRequest.TestId, putMarkAnswerRequest.QuestionId, putMarkAnswerRequest.AnswerId);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<PutGenerateTestResponse> PutGenerateTests(PutGenerateTestRequest generateTestRequest)
        {
            PutGenerateTestResponse result = new PutGenerateTestResponse();
            await _unitOfWork.GetRepository<ITestDetailRepository>().GenerateTests();
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
