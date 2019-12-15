using System.Linq;
using System.Threading.Tasks;
using OrderManager.DomainModel;

namespace OrderManager.DataAccess
{
    public interface IReadRepository<T> where T: EntityBase
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(long id);
    }
}