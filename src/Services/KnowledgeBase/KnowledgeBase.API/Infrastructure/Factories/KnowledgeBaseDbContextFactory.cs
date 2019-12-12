using KnowledgeBase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KnowledgeBase.API.Infrastructure.Factories
{
    public class KnowledgeBaseContextDesignFactory : IDesignTimeDbContextFactory<KnowledgeBaseDbContext>
    {
        public KnowledgeBaseDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
               .AddJsonFile("appsettings.json")
               .AddEnvironmentVariables()
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<KnowledgeBaseDbContext>();

            optionsBuilder.UseSqlServer(config["ConnectionString"], sqlServerOptionsAction: o => o.MigrationsAssembly("KnowledgeBase.API"));

            return new KnowledgeBaseDbContext(optionsBuilder.Options);
        }
    }
}
