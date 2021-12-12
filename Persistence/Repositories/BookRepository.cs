using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Persistence.Contexts;

namespace BookStoreSelling.API.Persistence.Repositories
{
  public class BookRepository : BaseRepository, IBookRepository
  {
    public BookRepository(AppDbContext context) : base(context)
    {
    }
  }
}