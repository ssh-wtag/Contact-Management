using ContactManagerClassLibrary.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ContactManagerClassLibrary.Infrastructure.Interfaces;
using ContactManagerClassLibrary.Infrastructure.Services;

namespace DEMO
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create a host builder to set up dependency injection
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register DbContext with dependency injection
                    services.AddDbContext<Context>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

                    // Register your service
                    services.AddScoped<IContactManager, ContactManagerService>();

                    // Register your main form
                    services.AddScoped<MainForm>();
                })
                .Build();

            // Run the application
            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}