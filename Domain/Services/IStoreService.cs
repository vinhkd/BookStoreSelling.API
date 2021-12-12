using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;

namespace BookStoreSelling.API.Domain.Services
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> ListAsync();
    }
}