using Identity.API.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Data
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
            ILogger<ApplicationDbContextSeed> logger, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;

            try
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetDefaultUser());

                    await context.SaveChangesAsync();
                }

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(GetDefaultRole());

                    await context.SaveChangesAsync();
                }

                if (!context.UserRoles.Any())
                {
                    Role role = context.Roles.FirstOrDefault(x => x.Name == "Admin");
                    foreach (User user in context.Users)
                    {
                        context.UserRoles.AddRange(new IdentityUserRole<Guid> { UserId = user.Id, RoleId = role.Id });
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    logger.LogError(ex.Message, $"There is an error migrating data for ApplicationDbContext");

                    await SeedAsync(context, env, logger, retryForAvaiability);
                }
            }
        }

        private IEnumerable<User> GetDefaultUser()
        {
            User user = new User()
            {
                Email = "demouser@microsoft.com",
                Id = Guid.NewGuid(),
                FirstName = "DemoUserFirstName",
                LastName = "DemoLastName",
                PhoneNumber = "1234567890",
                UserName = "demouser@microsoft.com",
                NormalizedEmail = "DEMOUSER@MICROSOFT.COM",
                NormalizedUserName = "DEMOUSER@MICROSOFT.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Pass@word1");

            return new List<User>()
            {
                user
            };
        }

        private IEnumerable<Role> GetDefaultRole()
        {
            Role adminRole = new Role()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            Role userRole = new Role()
            {
                Name = "User",
                NormalizedName = "USER"
            };

            return new List<Role>()
            {
                adminRole,
                userRole
            };
        }
    }
}
