
using Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Presentation;


public class Program
{
    
    public static void Main(string[] args)
    {
        //Setup Host environment, allowing for the use of an appsettings.json file for configuration as well as dependency injection.
        using IHost host = CreateHostBuilder(args).Build();
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        services.GetRequiredService<AssetManagementApp>().Run(args); // This is the entry point of the application

    }

    // This method is responsible for creating the host builder
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddEnvironmentVariables()
        .Build();


        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IConfiguration>(configuration);
                services.AddSingleton<AssetManagementApp>();
                services.AddApplicationServices();
                services.AddPersistenceServices(configuration);
            });
    }
}


