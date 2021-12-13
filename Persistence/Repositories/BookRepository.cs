using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStoreSelling.API.Persistence.Repositories
{
  public class BookRepository : BaseRepository, IBookRepository
  {
    public BookRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<QueryResult<Book>> ListAsync(BooksQuery query)
		{
			IQueryable<Book> queryable = _context.Books
													.Include(p => p.Store)
													.AsNoTracking();

			// AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
			// tracking makes the code a little faster
			if (query.StoreId.HasValue && query.StoreId > 0)
			{
				queryable = queryable.Where(p => p.StoreId == query.StoreId);
			}

			// Here I count all items present in the database for the given query, to return as part of the pagination data.
			int totalItems = await queryable.CountAsync();

			// Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
			// and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
			List<Book> books = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

			// Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
			return new QueryResult<Book>
			{
				Items = books,
				TotalItems = totalItems,
			};
		}

  }
}