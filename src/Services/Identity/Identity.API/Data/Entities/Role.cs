using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Identity.API.Data.Entities
{
    public class Role 
        : IdentityRole<Guid> { }
}