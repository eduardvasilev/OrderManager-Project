using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.DataAccess.Ef;
using OrderManager.DomainModel;

namespace OrderManager.DataAccess.Implementation
{
    public class ReadRepository<T> : IReadRepositry<T> where T : EntityBase
    {
        private readonly EfContext _context;

        public ReadRepository(EfContext context)
        {
            _context = context;
        }
      
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public Task<T> GetByIdAsync(long id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}