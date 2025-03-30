using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SqlConverter.Core.Services.Converters;
using SqlConverter.Domain.Interfaces;
using SqlConverter.Infrastructure.Converters;

namespace MYSQLToPLSQLConverter
{
    internal static class Program
    {
        private static IServiceProvider? _serviceProvider;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            Application.Run(_serviceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/sql-converter-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Register services
            services.AddLogging(builder => builder.AddSerilog(dispose: true));
            services.AddTransient<Form1>();
            services.AddTransient<IConverterHandler, DateFunctionsConverter>();
            // Add other converters here
        }
    }
}