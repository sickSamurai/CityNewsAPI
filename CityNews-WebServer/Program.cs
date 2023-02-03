using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


using System.IO;


namespace Service {
  public class Program {
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("Properties/appSettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
    
    public static IWebHost CreateHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseConfiguration(Configuration)
        .Build();
    
    public static void Main(string[] args) {
      using IWebHost webHost = CreateHostBuilder(args);
      webHost.Run();
    }


  }
}
