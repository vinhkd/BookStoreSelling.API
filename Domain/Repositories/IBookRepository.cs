using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;

namespace BookStoreSelling.API.Domain.Repositories
{
    public interface IBookRepository
    {
       Task<QueryResult<Book>> ListAsync(BooksQuery query); 
    }
}