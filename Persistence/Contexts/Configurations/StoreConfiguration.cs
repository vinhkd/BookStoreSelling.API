
using BookStoreSelling.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreSelling.API.Persistence.Contexts.Configurations
{
    public class StoreConfiguration: IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}