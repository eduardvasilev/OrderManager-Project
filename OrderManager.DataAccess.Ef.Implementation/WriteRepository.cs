using System.Threading.Tasks;
using OrderManager.DataAccess.Ef;
using OrderManager.DomainModel;

namespace OrderManager.DataAccess.Implementation
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase
    {
        private readonly EfContext _context;

        public WriteRepository(EfContext context)
        {
            _context = context;
        }
        
        public void Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}