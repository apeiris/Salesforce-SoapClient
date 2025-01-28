using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SoapClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // Set up the DI container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<Form1>() // Register Form1 as a dependency
                .BuildServiceProvider();

            // Initialize the application
            ApplicationConfiguration.Initialize();

            // Resolve Form1 from the service provider and run it
            var mainForm = serviceProvider.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }
    }
}
