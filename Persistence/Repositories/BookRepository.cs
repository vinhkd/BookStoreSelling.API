using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Persistence.Contexts;
using BookStoreSelling.API.Resources;
using Microsoft.EntityFrameworkCore;

namespace BookStoreSelling.API.Persistence.Repositories
{
  public class BookRepository : BaseRepository, IBookRepository
  {
    public BookRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<QueryResult<BookSpecific>> ListAsync(BooksQuery query)
    {
      var queryBookStore = _context.BookStores.AsNoTracking();
      if (query.StoreId.HasValue && query.StoreId > 0)
      {
        queryBookStore = queryBookStore.Where(x => x.StoreId == query.StoreId);
      }
      var queryable = _context.Books.AsQueryable()
                  .Join(queryBookStore.AsNoTracking(),
                  book => book.Id,
                  bookStore => bookStore.BookId,
                  (book, bookStore) => new 
                  {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    ISBNCode = book.ISBNCode,
										Price = bookStore.Price,
                    NumberLeftStock = bookStore.NumberLeftStock,
										UnitOfPrice = bookStore.UnitOfPrice
                  })
                  .GroupBy(x => new { x.Id, x.Name, x.Author, x.ISBNCode, x.UnitOfPrice })
                  .Select(y => new BookSpecific
                  {
                    Id = y.Key.Id,
                    Name = y.Key.Name,
                    Author = y.Key.Author,
                    ISBNCode = y.Key.ISBNCode,
                    MinPrice = y.Min(z => z.Price),
                    MaxPrice = y.Max(z => z.Price),
                    NumberLeftStock = y.Sum(z => z.NumberLeftStock),
										UnitOfPrice = y.Key.UnitOfPrice //TODO: Need to update value MinPrice and MaxPrice when UnitOfPrice different 
                  });
      if (!String.IsNullOrEmpty(query.Keyword))
      {
        queryable = queryable.Where(p => p.Name.Contains(query.Keyword));
      }

      // Here I count all items present in the database for the given query, to return as part of the pagination data.
      int totalItems = await queryable.CountAsync();

      // Here I apply a simple calculation to skip a given number of items, according to the current page and amount of items per page,
      // and them I return only the amount of desired items. The methods "Skip" and "Take" do the trick here.
      List<BookSpecific> books = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                .Take(query.ItemsPerPage)
                                                .ToListAsync();

      // // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
      return new QueryResult<BookSpecific>
      {
        Items = books,
        TotalItems = totalItems,
      };
    }
  }
}