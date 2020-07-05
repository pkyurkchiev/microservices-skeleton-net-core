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
        private readonly IIdentityService _identityService;

        public TestService(IUnitOfWork unitOfWork, IIdentityService identityService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("UnitOfWork");
            _identityService = identityService ?? throw new ArgumentNullException("IdentityService");
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

        public async Task<GetTestResultsResponse> GetTestResults(GetTestResultsRequest getTestResultsRequest)
        {
            GetTestResultsResponse result = new GetTestResultsResponse();
            IEnumerable<TestDetail> tests = await _unitOfWork.GetRepository<ITestDetailRepository>().GetTestResults(getTestResultsRequest.Id);
            result.TestDetailResults = tests.ConvertToViewModelResult();

            return result;
        }

        public async Task<PutMarkAnswerResponse> PutMarkAswer(PutMarkAnswerRequest putMarkAnswerRequest)
        {
            PutMarkAnswerResponse result = new PutMarkAnswerResponse();
            Guid userId = new Guid(_identityService.GetUserIdentity());
            await _unitOfWork.GetRepository<ITestDetailRepository>().MarkAnswer(putMarkAnswerRequest.TestId, putMarkAnswerRequest.QuestionId, putMarkAnswerRequest.AnswerId, userId);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<PutMarkTestFinishResponse> PutMarkTestFinish(PutMarkTestFinishRequest putMarkTestFinishRequest)
        {
            PutMarkTestFinishResponse result = new PutMarkTestFinishResponse();
            await _unitOfWork.GetRepository<ITestRepository>().MarkTestFinish(putMarkTestFinishRequest.TestId);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<PutGenerateTestResponse> PutGenerateTests(PutGenerateTestRequest generateTestRequest)
        {
            PutGenerateTestResponse result = new PutGenerateTestResponse();
            Guid userId = new Guid(_identityService.GetUserIdentity());
            await _unitOfWork.GetRepository<ITestDetailRepository>().GenerateTests(generateTestRequest.Description, userId);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
