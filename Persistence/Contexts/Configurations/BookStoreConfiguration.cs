using BookStoreSelling.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreSelling.API.Persistence.Contexts.Configurations
{
  public class BookStoreConfiguration : IEntityTypeConfiguration<BookStore>
  {
    public void Configure(EntityTypeBuilder<BookStore> builder)
    {
        builder.ToTable("BookStores");
        builder.HasKey(p => new { p.BookId, p.StoreId });
        builder.Property(p => p.BookId).IsRequired();
        builder.Property(p => p.StoreId).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.NumberLeftStock).IsRequired();
    }
  }
}