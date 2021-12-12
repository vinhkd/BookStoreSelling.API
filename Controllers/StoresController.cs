using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreSelling.API.Controllers
{
    public class StoresController : BaseController
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        /// <summary>
        /// Lists all stores.
        /// </summary>
        /// <returns>List os stores.</returns>
        [HttpGet]
        public async Task<IEnumerable<Store>> ListAsync()
        {
            var stores = await _storeService.ListAsync();
            return stores;
        }
    }
}