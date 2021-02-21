using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Common.Enums;
using CommonUtilities.Extensions;

namespace CommonUtilities
{
    public static class Tercmd
    {
        public static string InputName { get; set; }

        public class DotnetBuilder
        {
            private readonly string _directory;

            private DotnetBuilder(string directory)
            {
                _directory = directory;
            }

            public static DotnetBuilder Create(string directoryInfo)
            {
                return new DotnetBuilder(directoryInfo);
            }

            public DotnetBuilder AddMigration(string migrationName, int sleepTime = 0)
            {
                var proc = new Process
                {
                    StartInfo =
                    {
                        WorkingDirectory = _directory, FileName = TerminalKeys.Dotnet.ToLowerString(),
                        Arguments = $"ef migrations add {migrationName}",
                        CreateNoWindow = false
                    }
                };
                proc.Start();
                proc.WaitForExit();
                Thread.Sleep(sleepTime);
                return this;
            }
        }

        public class GitBuilder
        {
            private readonly DirectoryInfo _directory;

            private GitBuilder(DirectoryInfo directory)
            {
                _directory = directory;
            }

            public static GitBuilder Create(DirectoryInfo directory)
            {
                return new GitBuilder(directory);
            }

            public GitBuilder AddAllFiles()
            {
                var proc = new Process
                {
                    StartInfo =
                    {
                        WorkingDirectory = _directory.FullName, FileName = TerminalKeys.Git.ToLowerString(),
                        Arguments = $"add .",
                        CreateNoWindow = false
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return this;
            }
        }
    }
}