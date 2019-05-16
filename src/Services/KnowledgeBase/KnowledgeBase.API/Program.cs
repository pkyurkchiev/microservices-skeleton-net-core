using KnowledgeBase.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace KnowledgeBase.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .MigrateDbContext<KnowledgeBaseDbContext>((context, services) =>
                {
                    var configuration = services.GetService<IConfiguration>();
                    var env = services.GetService<IHostingEnvironment>();
                    var logger = services.GetService<ILogger<KnowledgeBaseDbContextSeed>>();

                    new KnowledgeBaseDbContextSeed()
                            .SeedAsync(context, env, configuration, logger)
                            .Wait();
                })
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, builder) =>
                {
                    builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .UseStartup<Startup>();
    }
}
