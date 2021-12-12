using AutoMapper;
using BookStoreSelling.API.Domain.Models;
using BookStoreSelling.API.Resources;

namespace BookStoreSelling.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Store, StoreResource>();
        }
    }
}