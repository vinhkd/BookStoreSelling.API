using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Domain.Services;

namespace BookStoreSelling.API.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IStoreRepository storeRepository, IUnitOfWork unitOfWork)
        {
            _storeRepository = storeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Store>> ListAsync()
        {
            return await _storeRepository.ListAsync();
        }
    }
}