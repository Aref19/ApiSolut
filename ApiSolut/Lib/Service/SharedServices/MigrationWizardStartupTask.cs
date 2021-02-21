using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;
using CommonUtilities;
using CommonUtilities.Extensions;
using CommonUtilities.Extensions.ExtensionModels;
using DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz.Util;

namespace Service.SharedServices
{
    public class MigrationWizardStartupTask : IStartupTask
    {
        private bool _restartWizard = false;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MigrationWizardStartupTask> _logger;

        public MigrationWizardStartupTask(IServiceProvider serviceProvider, ILogger<MigrationWizardStartupTask> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        private void CreateMigrationTerminalWizard()
        {
            try
            {
                var baseDir = DirectorySettings.GetSolutionDirectory();
                Console.WriteLine("Skipping in 3 seconds.... \nAdd new migration? (y/N)");
                var input = NConsole.ReadKeyWithTimeoutAsString();

                if (input == null || !input.ToLower().Equals("y"))
                    return;

                string migrationName;
                do
                {
                    Console.WriteLine("\nMigration or change name (camel case, no spaces input): ");
                    migrationName = Console.ReadLine();
                    if (migrationName?.TrimEmptyToNull() == null || migrationName.Split(" ").Length > 1)
                    {
                        _restartWizard = true;
                        Console.WriteLine(
                            "Incorrect input, please enter the name in CamelCase format and try again....");
                    }
                    else
                    {
                        _restartWizard = false;
                    }
                } while (_restartWizard);

                _logger.LogInformation("Creating migration....");

                var migrationTask = new Task(() =>
                    {
                        Tercmd.DotnetBuilder.Create(baseDir.MigrationsPathFromRoot())
                            .AddMigration(migrationName, 5000);
                    });
                migrationTask.Start();
                migrationTask.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            CreateMigrationTerminalWizard();
            Tercmd.GitBuilder.Create(DirectorySettings.GetSolutionDirectory()).AddAllFiles();
            return Task.CompletedTask;
        }
    }
}