using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Domain.Services;
using BookStoreSelling.API.Infrastructure;
using Microsoft.Extensions.Caching.Memory;

namespace BookStoreSelling.API.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }
        public async Task<IEnumerable<Store>> ListAsync()
        {
            var stores = await _cache.GetOrCreateAsync(CacheKeys.StoresList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _storeRepository.ListAsync();
            });
            
            return stores;
        }
    }
}