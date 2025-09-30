using AutoMapper;
using co_lib.Dtos;
using Coffeshop.Models;

namespace Coffeshop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}