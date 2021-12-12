using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreSelling.API.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}