using Identity.API.Data.Entities;
using Identity.API.Messages.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class RolesController : Controller
    {
        private readonly RoleManager<Role> _roleManager;

        public RolesController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleRequestMessage model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Role newRole = new Role()
            {
                Name = model.Name,
                NormalizedName = model.NormalizedName
            };

            try
            {
                Role role = await _roleManager.FindByNameAsync(newRole.Name);

                if (role == null)
                {
                    IdentityResult result = await _roleManager.CreateAsync(newRole);

                    if (result.Succeeded)
                    {
                        return Ok();
                    }

                    return BadRequest("Creating of new role failed");
                }

                return BadRequest("There's already role with this name");

            }
            catch (Exception ex)
            {
                return BadRequest($"Creating of new role failed with error {ex.Message}");
            }
        }
    }
}
