using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;

namespace BookStoreSelling.API.Domain.Repositories
{
    public interface IBookRepository
    {
       Task<QueryResult<BookSpecific>> ListAsync(BooksQuery query); 
       Task<BookInStore> GetAsync(int id);
    }
}