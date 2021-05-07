
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Faro.MetrologyManager.Adapters.EFCore.Contexts.Interfaces
{
    public interface IDbContext
    {
        DbSet<TDataModel> Set<TDataModel>() where TDataModel : class;
        EntityEntry<TDataModel> Entry<TDataModel>(TDataModel entity) where TDataModel : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
