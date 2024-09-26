
using Microsoft.AspNetCore;
using Serilog;

namespace Pinnacle.PIS.Server
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables()
             .Build();
            CreateHostBuilder(args).UseConfiguration(config).Build().Run();

        }
        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
     WebHost.CreateDefaultBuilder(args)
         .UseStartup<Startup>()
         .UseContentRoot(Directory.GetCurrentDirectory())
         .UseShutdownTimeout(TimeSpan.FromSeconds(10))
         .ConfigureLogging((context, logging) =>
         {
             object value = logging.ClearProviders(); // Optional: Remove other logging providers if only using Serilog
             logging.AddSerilog(new LoggerConfiguration()
                 .ReadFrom.Configuration(context.Configuration)
                 .CreateLogger());
         });

    }
}
