using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Persistence.Contexts;

namespace BookStoreSelling.API.Persistence.Repositories
{
    public class StoreRepository: BaseRepository, IStoreRepository
    {
        public StoreRepository(AppDbContext context) : base(context)
        {
        }
        public Task<IEnumerable<Store>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}