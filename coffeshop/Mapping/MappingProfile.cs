using AutoMapper;
using Coffeshop.Dto;
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