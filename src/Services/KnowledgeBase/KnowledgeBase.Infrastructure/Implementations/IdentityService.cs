using KnowledgeBase.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using System;

namespace KnowledgeBase.Infrastructure.Implementations
{
    public class IdentityService : ApplicationServiceBase, IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string GetUserIdentity()
        {
            return _context.HttpContext.User.FindFirst("sub").Value;
        }

        public string GetUserName()
        {
            return _context.HttpContext.User.Identity.Name;
        }
    }
}
