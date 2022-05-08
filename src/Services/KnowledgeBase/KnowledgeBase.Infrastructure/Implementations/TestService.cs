using KnowledgeBase.Infrastructure.Messaging.TestDetails;
using KnowledgeBase.Infrastructure.Messaging.Tests;
using KnowledgeBase.Data.Entities;
using KnowledgeBase.Data.Repositories;
using KnowledgeBase.Infrastructure.Interfaces;
using KnowledgeBase.Infrastructure.ModelConversions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeBase.Data.Entities.Enums;
using Microsoft.Extensions.Logging;

namespace KnowledgeBase.Infrastructure.Implementations
{
    public class TestService : ApplicationServiceBase, ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;

        public TestService(IUnitOfWork unitOfWork, IIdentityService identityService, ILogger<TestService> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException("UnitOfWork");
            _identityService = identityService ?? throw new ArgumentNullException("IdentityService");
            _logger = logger ?? throw new ArgumentNullException("Logger");
        }

        public async Task<GetTestsResponse> GetTests()
        {
            GetTestsResponse result = new GetTestsResponse();
            string externalUserId = _identityService.GetUserIdentity();
            _logger.LogInformation("Log user: {externalUserId}", externalUserId);
            IList<Test> tests = await _unitOfWork.GetRepository<ITestRepository>().GetByUserId(new Guid(externalUserId));
            result.Tests = tests.ConvertToTestViewModel();

            return result;
        }

        public async Task<GetTestDetailsResponse> GetTestDetailsByTestId(GetTestDetailsRequest getTestDetailsRequest)
        {
            GetTestDetailsResponse result = new GetTestDetailsResponse();
            IEnumerable<TestDetail> tests = await _unitOfWork.GetRepository<ITestDetailRepository>().GetByTestId(getTestDetailsRequest.TestId);
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
            Guid externalUserId = new Guid(_identityService.GetUserIdentity());
            await _unitOfWork.GetRepository<ITestDetailRepository>().MarkAnswer(putMarkAnswerRequest.TestId, putMarkAnswerRequest.QuestionId, putMarkAnswerRequest.AnswerId, externalUserId);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<PutMarkTestFinishResponse> PutMarkTestFinish(PutMarkTestFinishRequest putMarkTestFinishRequest)
        {
            PutMarkTestFinishResponse result = new PutMarkTestFinishResponse();
            var currectAnswers = await _unitOfWork.GetRepository<ITestDetailRepository>().GetByTestId(putMarkTestFinishRequest.TestId);
            await _unitOfWork.GetRepository<ITestRepository>().MarkTestFinish(putMarkTestFinishRequest.TestId, currectAnswers.Count >= 6 ? ExecutionStatusEnum.Passed : ExecutionStatusEnum.Failed);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<PutGenerateTestResponse> PutGenerateTests(PutGenerateTestRequest generateTestRequest)
        {
            PutGenerateTestResponse result = new PutGenerateTestResponse();
            Guid userId = new Guid(_identityService.GetUserIdentity());
            await _unitOfWork.GetRepository<ITestDetailRepository>().GenerateTests(generateTestRequest.DisciplineId, generateTestRequest.Body.Description, userId);
            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
