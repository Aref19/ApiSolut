using System.Threading.Tasks;

namespace CommonUtilities.Extensions
{
    public static class TaskExtensions
    {
        public static void StartAndWait(this Task task)
        {
            task.Start();
            task.Wait();
        }
    }
}