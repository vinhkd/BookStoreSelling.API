using AutoMapper;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Domain.Models.Queries;
using BookStoreSelling.API.Extensions;
using BookStoreSelling.API.Resources;

namespace BookStoreSelling.API.Mapping
{
  public class ModelToResourceProfile : Profile
  {
    public ModelToResourceProfile()
    {
      CreateMap<Store, StoreResource>();
      CreateMap<BookSpecific, BookResource>()
            .ForMember(src => src.UnitOfPrice,
                        opt => opt.MapFrom(src => src.UnitOfPrice.ToDescriptionString()));
      CreateMap<StoreWithPrice, StoreWithPriceResource>()
            .ForMember(src => src.UnitOfPrice,
                        opt => opt.MapFrom(src => src.UnitOfPrice.ToDescriptionString()));
      CreateMap<BookInStore, BookInStoreResource>();
      CreateMap<QueryResult<BookSpecific>, QueryResultResource<BookResource>>();
    }
  }
}