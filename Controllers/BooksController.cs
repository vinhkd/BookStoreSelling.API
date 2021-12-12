using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Services;
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
    }
}