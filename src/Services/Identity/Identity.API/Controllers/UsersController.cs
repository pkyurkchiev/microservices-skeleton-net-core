using Identity.API.Data.Entities;
using Identity.API.Helpers;
using Identity.API.Messages.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userResponseMessages = new List<UserResponseMessage>();
                foreach (User user in await _userManager.Users.ToListAsync())
                {
                    userResponseMessages.Add(new UserResponseMessage
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        NormalizedUserName = user.NormalizedUserName,
                        Email = user.NormalizedEmail,
                        NormalizedEmail = user.NormalizedEmail,
                        RoleNames = await _userManager.GetRolesAsync(user)
                    });
                }        

                return Ok(userResponseMessages);
            }
            catch (Exception ex)
            {
                //  _logger.LogError($"Exception thrown while looing in: {ex}");
                return BadRequest($"List users failed with error {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == id);
                var userResponseMessages = new UserResponseMessage
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    NormalizedUserName = user.NormalizedUserName,
                    Email = user.NormalizedEmail,
                    NormalizedEmail = user.NormalizedEmail,
                    RoleNames = await _userManager.GetRolesAsync(user)
                };

                return Ok(userResponseMessages);
            }
            catch (Exception ex)
            {
                //  _logger.LogError($"Exception thrown while looing in: {ex}");
                return BadRequest($"Get user by id failed with error {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequestMessage model)
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

                return BadRequest("Failed to register");
            }
            catch (Exception ex)
            {
                //  _logger.LogError($"Exception thrown while looing in: {ex}");
                return BadRequest($"Creating of new role failed with error {ex.Message}");
            }
        }
    }
}
