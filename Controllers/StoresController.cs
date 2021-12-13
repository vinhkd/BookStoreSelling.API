using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Services;
using BookStoreSelling.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreSelling.API.Controllers
{
    public class StoresController : BaseController
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoresController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all stores.
        /// </summary>
        /// <returns>List os stores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreResource>), 200)]
        public async Task<IEnumerable<StoreResource>> ListAsync()
        {
            var stores = await _storeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);
            return resources;
        }
    }
}