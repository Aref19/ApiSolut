using System.IO;
using System.Linq;

namespace CommonUtilities.Extensions
{
    public static class DirectoryExtensions
    {
        public static DirectoryInfo SetDepth(this DirectoryInfo info, int depth)
        {
            for (var i = 0; i <= depth; i++)
            {
                info = info?.Parent;
            }

            return info;
        }

        public static DirectoryInfo BasePath(this DirectoryInfo directory)
        {
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }

        public static string MigrationsPathFromRoot(this DirectoryInfo directoryInfo) =>
            Path.Combine(directoryInfo.FullName, "ApiSolut\\Lib\\Migrations");
    }
}