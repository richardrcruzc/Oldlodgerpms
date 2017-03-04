using System.Threading;
using System.Threading.Tasks;

namespace LodgerPms.CoreLibs.Domain
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges(CancellationToken calCancellationToken = default(CancellationToken));
    }
}