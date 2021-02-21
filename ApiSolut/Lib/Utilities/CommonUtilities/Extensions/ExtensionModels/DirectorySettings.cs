using System.IO;

namespace CommonUtilities.Extensions.ExtensionModels
{
    public static class DirectorySettings
    {
        public static DirectoryInfo GetSolutionDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory())?.BasePath();
        }
    }
}