using System.Collections.Generic;

namespace BookStoreSelling.API.Resources
{
    public class BookInStoreResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBNCode { get; set; }
        public IList<StoreWithPriceResource> StoreWithPrices { get; set; } = new List<StoreWithPriceResource>();
    }
}