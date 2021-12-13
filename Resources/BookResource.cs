using BookStoreSelling.API.Domain.Models;

namespace BookStoreSelling.API.Resources
{
    public class BookResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBNCode { get; set; }
        public int NumberLeftStock { get; set; }
        public EUnitOfPrice UnitOfPrice { get; set; }
        public StoreResource Store { get; set; }
    }
}