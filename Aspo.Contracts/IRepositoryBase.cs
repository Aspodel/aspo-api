using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aspo.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        Task<T> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
