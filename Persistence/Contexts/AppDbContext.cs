using System.Reflection;
using BookStoreSelling.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace BookStoreSelling.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}