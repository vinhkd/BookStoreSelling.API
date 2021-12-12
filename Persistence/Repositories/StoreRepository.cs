using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Repositories;
using BookStoreSelling.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookStoreSelling.API.Persistence.Repositories
{
    public class StoreRepository: BaseRepository, IStoreRepository
    {
        public StoreRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Store>> ListAsync()
        {
            return await _context.Stores.AsNoTracking().ToListAsync();
        }
    }
}