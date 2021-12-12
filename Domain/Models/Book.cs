namespace BookStoreSelling.API.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBNCode { get; set; }
        public int NumberLeftStock { get; set; }
        public EUnitOfPrice UnitOfPrice { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}