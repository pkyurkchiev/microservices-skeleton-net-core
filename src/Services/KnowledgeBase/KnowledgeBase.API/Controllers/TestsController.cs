using KnowledgeBase.ApplicationServices.Interfaces;
using KnowledgeBase.ApplicationServices.Messaging;
using KnowledgeBase.ApplicationServices.Messaging.TestDetails;
using KnowledgeBase.ApplicationServices.Messaging.Tests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService ?? throw new ArgumentNullException("TestService in TestsController");
        }

        [HttpGet("{testId}/users/{userId}")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> GetTestDetailsByUserId([FromRoute] Guid userId, [FromRoute] Guid testId)
        {
            ServiceResponseBase response = await _testService.GetTestDetailsByUserId(new GetTestDetailsRequest(userId));
            return Ok(response);
        }

        [HttpGet("users/{userExternalId}")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> GetTestDetailsByUserExternalId([FromRoute] string userExternalId)
        {
            ServiceResponseBase response = await _testService.GetTestDetailsByUserExternalId(new GetTestDetailsByUserExternalIdRequest(userExternalId));
            return Ok(response);
        }

        [HttpPut("{testId}/questions/{questionId}/answers/{answerId}/mark")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> MarkAnswer([FromRoute] Guid testId, [FromRoute] Guid questionId, [FromRoute] Guid answerId)
        {
            ServiceResponseBase response = await _testService.PutMarkAswer(new PutMarkAnswerRequest(testId, questionId, answerId));
            return Ok(response);
        }

        [HttpPut("generator")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> Generate()
        {
            ServiceResponseBase response = await _testService.PutGenerateTests(new PutGenerateTestRequest());
            return Ok(response);
        }
    }
}
