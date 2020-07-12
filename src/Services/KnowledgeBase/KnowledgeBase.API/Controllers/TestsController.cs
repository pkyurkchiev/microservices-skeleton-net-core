using KnowledgeBase.Infrastructure.Interfaces;
using KnowledgeBase.Infrastructure.Messaging;
using KnowledgeBase.Infrastructure.Messaging.TestDetails;
using KnowledgeBase.Infrastructure.Messaging.Tests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService ?? throw new ArgumentNullException("TestService in TestsController");
        }

        [HttpGet]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> GetTests()
        {
            ServiceResponseBase response = await _testService.GetTests();
            return Ok(response);
        }

        [HttpGet("{testId}")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> GetTestDetailsByUserId([FromRoute] Guid testId)
        {
            ServiceResponseBase response = await _testService.GetTestDetailsByTestId(new GetTestDetailsRequest(testId));
            return Ok(response);
        }

        [HttpGet("users/{userExternalId}")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> GetTestDetailsByUserExternalId([FromRoute] string userExternalId)
        {
            ServiceResponseBase response = await _testService.GetTestDetailsByUserExternalId(new GetTestDetailsByUserExternalIdRequest(userExternalId));
            return Ok(response);
        }

        [HttpGet("{testId}/results")]
        public async Task<IActionResult> GetTestResults([FromRoute] Guid testId)
        {
            ServiceResponseBase response = await _testService.GetTestResults(new GetTestResultsRequest(testId));
            return Ok(response);
        }

        [HttpPut("{testId}/questions/{questionId}/answers/{answerId}/mark")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> MarkAnswer([FromRoute] Guid testId, [FromRoute] Guid questionId, [FromRoute] Guid answerId)
        {
            ServiceResponseBase response = await _testService.PutMarkAswer(new PutMarkAnswerRequest(testId, questionId, answerId));
            return Ok(response);
        }

        [HttpPut("{testId}/finish")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> MarkTestFinish([FromRoute] Guid testId)
        {
            ServiceResponseBase response = await _testService.PutMarkTestFinish(new PutMarkTestFinishRequest(testId));
            return Ok(response);
        }

        [HttpPut("disciplines/{disciplineId}/generator")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> Generate([FromRoute] Guid disciplineId, [FromBody] BodyModel body)
        {
            ServiceResponseBase response = await _testService.PutGenerateTests(new PutGenerateTestRequest(disciplineId, body));
            return Ok(response);
        }
    }
}
