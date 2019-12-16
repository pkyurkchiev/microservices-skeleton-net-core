using KnowledgeBase.ApplicationServices.Interfaces;
using KnowledgeBase.ApplicationServices.Messaging;
using KnowledgeBase.ApplicationServices.Messaging.Tests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService ?? throw new ArgumentNullException("TestService in PizzasController");
        }

        [HttpGet("users/{userId}")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> GetById([FromRoute] Guid userId)
        {
            ServiceResponseBase response = await _testService.GetByUserId(new GetTestQuestionAnswersRequest { UserId = userId });
            return Ok(response);
        }

        [HttpPut("generator")]
        public async Task<IActionResult> Generate()
        {
            ServiceResponseBase response = await _testService.PutGenerateTests(new GenerateTestRequest());
            return Ok(response);
        }
    }
}
