using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeBase.ApplicationServices.Interfaces;
using KnowledgeBase.ApplicationServices.Messaging;
using KnowledgeBase.ApplicationServices.Messaging.Tests;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/values/5
        [HttpGet("{id}")]
        [Produces(typeof(ServiceResponseBase))]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            ServiceResponseBase response = await _testService.GetById(new GetTestRequest(id));
            return Ok(response);
        }

        // POST api/values
        [HttpPut]
        public async Task<IActionResult> Generate()
        {
            ServiceResponseBase response = await _testService.PutGenerateTests(new GenerateTestRequest());
            return Ok(response);
        }
    }
}
