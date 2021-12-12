using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreSelling.API.Domain.Models;

namespace BookStoreSelling.API.Persistence.Contexts
{
    public static class SeedData
    {
     public static async Task Seed(AppDbContext context)
        {
            var books = new List<Book>
            {
                new Book
                {
                    Id = 100,
                    Name = "Born in the USA",
                    Author = "Barack Obama and Bruce Springsteen",
                    ISBNCode = "9780593236314",
                    NumberLeftStock = 34,
                    UnitOfPrice = EUnitOfPrice.USD,
                    StoreId = 100
                },
                new Book
                {
                    Id = 101,
                    Name = "The Story of Schitt's Creek",
                    Author = "Daniel Levy, Eugene Levy",
                    ISBNCode = "9780762499502",
                    NumberLeftStock = 45,
                    UnitOfPrice = EUnitOfPrice.USD,
                    StoreId = 101
                }
            };

            var stores = new List<Store>
            {
                new Store { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new Store { Id = 101, Name = "Dairy" }
            };

            context.Books.AddRange(books);
            context.Stores.AddRange(stores);

            await context.SaveChangesAsync();
        }   
    }
}