using System;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Domain.Services;
using BookStoreSelling.API.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace BookStoreSelling.API.Services
{
  public class BookService : IBookService
  {
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemoryCache _cache;

    public BookService(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
    {
      _bookRepository = bookRepository;
      _unitOfWork = unitOfWork;
      _cache = cache;
    }

    public async Task<BookInStore> GetAsync(int id)
    {
      return await _bookRepository.GetAsync(id);
    }

    public async Task<QueryResult<BookSpecific>> ListAsync(BooksQuery query)
    {
      //Maybe should remove the cache to support search keyword
      // string cacheKey = GetCacheKeyForBooksQuery(query);

      // var books = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
      //     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
      //     return _bookRepository.ListAsync(query);
      // });

      return await _bookRepository.ListAsync(query);
    }

    private string GetCacheKeyForBooksQuery(BooksQuery query)
    {
      string key = CacheKeys.BooksList.ToString();
      if (query.StoreId.HasValue && query.StoreId > 0)
      {
        key = string.Concat(key, "_", query.StoreId.Value);
      }
      key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
      return key;
    }
  }
}