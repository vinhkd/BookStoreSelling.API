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
        public async Task<QueryResult<Book>> ListAsync(BooksQuery query)
        {
            // Here I list the query result from cache if they exist, but now the data can vary according to the Store ID, page and amount of
            // items per page. I have to compose a cache to avoid returning wrong data.
            string cacheKey = GetCacheKeyForBooksQuery(query);
            
            var books = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _bookRepository.ListAsync(query);
            });

            return books;
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