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
                    Id = 99,
                    Name = "Born in the USA",
                    Author = "Barack Obama and Bruce Springsteen",
                    ISBNCode = "9780593236314",
                },
                new Book
                {
                    Id = 100,
                    Name = "The Story of Schitt's Creek",
                    Author = "Daniel Levy, Eugene Levy",
                    ISBNCode = "9780762499502",
                },new Book
                {
                    Id = 101,
                    Name = "Disney Dreams Collection Thomas Kinkade Studios Coloring",
                    Author = "Thomas Kinkade",
                    ISBNCode = "9780762488512",
                },
                new Book
                {
                    Id = 102,
                    Name = "Wall Calendar",
                    Author = "Daniel Levy, Eugene Levy",
                    ISBNCode = "9780761523584",
                }
            };

            var stores = new List<Store>
            {
                new Store { Id = 001, Name = "Fruits and Vegetables" },
                new Store { Id = 002, Name = "Dairy" }
            };

            var bookStores = new List<BookStore>
            {
                new BookStore 
                { 
                    StoreId = 001,
                    BookId = 99,
                    Price = 55.3F,
                    NumberLeftStock = 32,
                    UnitOfPrice = EUnitOfPrice.USD
                },
                new BookStore 
                { 
                    StoreId = 001,
                    BookId = 100,
                    Price = 12.3F,
                    NumberLeftStock = 12,
                    UnitOfPrice = EUnitOfPrice.USD
                },
                new BookStore 
                { 
                    StoreId = 001,
                    BookId = 101,
                    Price = 98.0F,
                    NumberLeftStock = 90,
                    UnitOfPrice = EUnitOfPrice.USD
                },
                new BookStore 
                { 
                    StoreId = 002,
                    BookId = 102,
                    Price = 53.5F,
                    NumberLeftStock = 35,
                    UnitOfPrice = EUnitOfPrice.USD
                },
                new BookStore 
                { 
                    StoreId = 002,
                    BookId = 99,
                    Price = 54.3F,
                    NumberLeftStock = 100,
                    UnitOfPrice = EUnitOfPrice.USD
                }
            };

            context.Books.AddRange(books);
            context.Stores.AddRange(stores);
            context.BookStores.AddRange(bookStores);

            await context.SaveChangesAsync();
        }   
    }
}