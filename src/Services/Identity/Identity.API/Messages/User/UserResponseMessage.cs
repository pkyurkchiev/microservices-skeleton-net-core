using System;
using System.Collections.Generic;

namespace Identity.API.Messages.User
{
    public class UserResponseMessage
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public Guid[] RoleIds { get; set; }

        public IList<string> RoleNames { get; set; }
    }
}
