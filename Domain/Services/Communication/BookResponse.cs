using BookStoreSelling.API.Domain.Models;

namespace BookStoreSelling.API.Domain.Services.Communication
{
    public class BookResponse : BaseResponse<Book>
    {
        public BookResponse(Book book) : base(book) { }

        public BookResponse(string message) : base(message) { }
    }
}