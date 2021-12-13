using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;
using BookStoreSelling.API.Domain.Services;
using BookStoreSelling.API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreSelling.API.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Lists available books
        /// </summary>
        /// <returns>List os available books.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<BookResource>), 200)]
        public async Task<QueryResultResource<BookResource>> ListAsync([FromQuery] BooksQueryResource query)
        {
            var booksQuery = _mapper.Map<BooksQueryResource, BooksQuery>(query);
            var queryResult = await _bookService.ListAsync(booksQuery);

            var resource = _mapper.Map<QueryResult<Book>, QueryResultResource<BookResource>>(queryResult);
            return resource;
        }
    }
}