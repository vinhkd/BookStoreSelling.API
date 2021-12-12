using System.Collections.Generic;

namespace BookStoreSelling.API.Domain.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; } = new List<Book>();
    }
}