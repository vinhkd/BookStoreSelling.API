using System.Collections.Generic;

namespace BookStoreSelling.API.Domain.Models.Queries
{
    public class BookInStore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBNCode { get; set; }
        public IList<StoreWithPrice> StoreWithPrices { get; set; } = new List<StoreWithPrice>();
    }
}