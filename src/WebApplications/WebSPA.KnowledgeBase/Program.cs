using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace WebSPA.KnowledgeBase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .ConfigureAppConfiguration((builderContext, config) =>
                            {
                                config.AddEnvironmentVariables();
                            })
                            .UseSerilog((builderContext, config) =>
                            {
                                config
                                    .MinimumLevel.Information()
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console();
                            }).Build();
    }
}
