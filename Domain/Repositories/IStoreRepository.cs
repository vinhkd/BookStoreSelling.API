using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;

namespace BookStoreSelling.API.Domain.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> ListAsync();
    }
}