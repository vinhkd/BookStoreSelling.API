namespace BookStoreSelling.API.Domain.Models
{
    public class BookSpecific
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBNCode { get; set; }
        public float MinPrice { get; set; }
        public float MaxPrice { get; set; }
        public int NumberLeftStock { get; set; }
        public EUnitOfPrice UnitOfPrice { get; set; }
    }
}