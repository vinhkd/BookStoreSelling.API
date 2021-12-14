namespace BookStoreSelling.API.Domain.Models
{
    public class BookStore
    {
        public int StoreId { get; set; }
        public int BookId { get; set; }
        public float Price { get; set; }
        public EUnitOfPrice UnitOfPrice { get; set; }
        public int NumberLeftStock { get; set; }
    }
}