using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace KnowledgeBase.Data
{
    public class KnowledgeBaseDbContextSeed
    {
        public async Task SeedAsync(KnowledgeBaseDbContext context, IHostingEnvironment env, Microsoft.Extensions.Configuration.IConfiguration settings, ILogger<KnowledgeBaseDbContextSeed> logger)
        {
            await context.SaveChangesAsync();
        }
    }
}
