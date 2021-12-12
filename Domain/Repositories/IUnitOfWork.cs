using System.Threading.Tasks;

namespace BookStoreSelling.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}