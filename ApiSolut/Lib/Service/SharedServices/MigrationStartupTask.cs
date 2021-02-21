using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Service.SharedServices
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MigrationStartupTask : IStartupTask
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MigrationStartupTask> _logger;

        public MigrationStartupTask(IServiceProvider serviceProvider, ILogger<MigrationStartupTask> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        private async Task MigrateDatabaseAsync()
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                _logger.LogInformation("Initializing Db connection....");
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
                var pendingMigrationsCount = pendingMigrations.Count();
                _logger.LogInformation("Starting Migrations, migrations pending: {0}", pendingMigrationsCount);
                await db.Database.MigrateAsync();
                _logger.LogInformation("Migrations finished successfully with {0} migration changes",
                    pendingMigrationsCount);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to initialize db connection.\nStacktrace....");
                throw new Exception("Failed to start db migration task, end of process.\nStacktrace....");
            }
        }

        private async Task AddMigrationsToDatabaseAsync()
        {
            
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            await AddMigrationsToDatabaseAsync();
            await MigrateDatabaseAsync();
        }

    }
}