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

        public async Task SeedAsync(ApplicationDbContext context, IHostingEnvironment env,
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
            var user =
            new User()
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
            var role = new Role()
            {
                Name = "Admin",
                NormalizedName = "Admin"
            };

            return new List<Role>()
            {
                role
            };
        }
    }
}
