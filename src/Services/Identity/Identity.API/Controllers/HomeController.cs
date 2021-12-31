using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Services;
using Identity.API.ViewModels;
using System.Threading.Tasks;
using Identity.API.Services;

namespace Identity.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IRedirectService _redirectSvc;

        public HomeController(IIdentityServerInteractionService interaction, IRedirectService redirectSvc)
        {
            _interaction = interaction;
            _redirectSvc = redirectSvc;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }

        public IActionResult ReturnToOriginalApplication(string returnUrl)
        {
            if (returnUrl != null)
                return Redirect(_redirectSvc.ExtractRedirectUriFromReturnUrl(returnUrl));
            else
                return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }
    }
}
