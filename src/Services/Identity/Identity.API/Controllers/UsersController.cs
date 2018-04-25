using Identity.API.Data.Entities;
using Identity.API.Helpers;
using Identity.API.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserVM model)
        {
            if (!ModelState.IsValid)
            {
                // return 422
                return new UnprocessableObjectResult(ModelState);
            }

            try
            {
                User user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
              
                if (result.Succeeded)
                {
                    var currentUser = _userManager.FindByIdAsync(user.Id.ToString());

                    var roleresult = _userManager.AddToRoleAsync(user, "User");

                    return Ok();
                }

            }
            catch (Exception ex)
            {
              //  _logger.LogError($"Exception thrown while looing in: {ex}");
            }

            return BadRequest("Failed to register");
        }
    }
}
