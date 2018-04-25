using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Identity.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using IdentityServer4.Stores;

namespace Identity.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clients;
        private readonly IResourceStore _resources;

        public ProfileService(UserManager<User> userManager, RoleManager<Role> roleManager, IIdentityServerInteractionService interaction,
            IClientStore clients,
            IResourceStore resources)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _interaction = interaction;
            _clients = clients;
            _resources = resources;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();

            var user = await _userManager.FindByIdAsync(subjectId);

            if (user == null)
                throw new ArgumentException("Invalid subject identifier");

            var claims = GetClaimsFromUser(user);
            context.IssuedClaims = claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.GetSubjectId();

            var user = await _userManager.FindByIdAsync(subjectId);

            context.IsActive = false;

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var roles = _roleManager.Roles.ToList();

                if (userRoles.Count > 0)
                {

                    if (_userManager.SupportsUserSecurityStamp)
                    {
                        var securityStamp = subject.Claims.Where(c => c.Type == "security_stamp").Select(c => c.Value).SingleOrDefault();

                        if (securityStamp != null)
                        {
                            var dbSecurityStamp = await _userManager.GetSecurityStampAsync(user);

                            if (dbSecurityStamp != securityStamp)
                                return;
                        }
                    }

                    context.IsActive =
                        !user.LockoutEnabled ||
                        !user.LockoutEnd.HasValue ||
                        user.LockoutEnd <= DateTime.Now;
                }
                else
                {
                    context.IsActive = true;
                }

            }
        }

        private IEnumerable<Claim> GetClaimsFromUser(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.PreferredUserName, user.UserName),
                new Claim(JwtClaimTypes.Role, "user")
            };

            if (!string.IsNullOrWhiteSpace(user.FirstName))
                claims.Add(new Claim("first_name", user.FirstName));

            if (!string.IsNullOrWhiteSpace(user.LastName))
                claims.Add(new Claim("last_name", user.LastName));

            return claims;
        }
    }
}
