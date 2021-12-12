using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Persistence.Contexts;

namespace BookStoreSelling.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
  }
}