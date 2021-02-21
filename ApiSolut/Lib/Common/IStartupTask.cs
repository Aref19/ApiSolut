using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public interface IStartupTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}