using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Factories;
using CommonUtilities.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DbEntities.Extensions
{
    public static class DbExtensions
    {
        public static async Task<IHost> MigrateOnRuntime(this IHost host)
        {
            var dbLogger = DbLogger(host);
            try
            {
                using var scope = host.Services.CreateScope();
                dbLogger.LogInformation("Initializing Db connection....");
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
                var pendingMigrationsCount = pendingMigrations.Count();
                dbLogger.LogInformation("Starting Migrations, migrations pending: {0}", pendingMigrationsCount);
                await db.Database.MigrateAsync();
                dbLogger.LogInformation("Migrations finished successfully with {0} migration changes",
                    pendingMigrationsCount);
            }
            catch (Exception e)
            {
                dbLogger.LogError(e, "Failed to initialize db connection.\nStacktrace....");
                throw new Exception("Failed to start db migration task, end of process.\nStacktrace....");
            }

            return host;
        }

        private static ILogger<AppDbContext> DbLogger(IHost host) =>
            host.Services.GetService<ILogger<AppDbContext>>();

        private static IConfigurationRoot UseDefaultConfigurationBuilder(this IConfigurationBuilder builder) =>
            builder.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).BasePath().FullName)
                .AddJsonFile("ServiceConfig.Development.json")
                .Build();

        public static DbContextOptionsBuilder UseDefaultConnectionConfiguration(this DbContextOptionsBuilder builder,
            string migrationsAssembly = null)
        {
            var config = new ConfigurationBuilder().UseDefaultConfigurationBuilder();
            return builder.UseSqlServer(
                    config.GetConnectionString("default"),
                    optionsBuilder => optionsBuilder.MigrationsAssembly(migrationsAssembly)
                )
                .UseLoggerFactory(CustomLoggingFactory.CreateInformationLoggingFactory)
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}