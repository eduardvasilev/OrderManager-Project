using System.Threading.Tasks;
using OrderManager.DomainModel;

namespace OrderManager.DataAccess
{
    public interface IWriteRepository<T> where T : EntityBase
    {
        void Create(T entity);

        Task SaveChangesAsync();

        void Update(T entity);
    }
}