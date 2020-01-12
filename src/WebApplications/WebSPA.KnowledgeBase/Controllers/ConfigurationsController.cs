using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebSPA.KnowledgeBase.Setup;

namespace WebSPA.KnowledgeBase.Controllers
{

    [Route("api/[controller]")]
    public class ConfigurationsController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly IOptionsSnapshot<AppSettings> _settings;

        public ConfigurationsController(IHostingEnvironment env, IOptionsSnapshot<AppSettings> settings)
        {
            _env = env;
            _settings = settings;
        }

        [HttpGet("[action]")]
        public JsonResult Main()
        {
            return Json(_settings.Value);
        }
    }
}