using AutoMapper;
using BookStoreSelling.API.Domain.Models.Queries;
using BookStoreSelling.API.Resources;

namespace BookStoreSelling.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<BooksQueryResource, BooksQuery>();
        }
    }
}