using AutoMapper;
using Shop.API.Domain.Models;
using Shop.API.Resources;

namespace Shop.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveManufacturerResource, Manufacturer>();
            CreateMap<SaveGoodResource, Good>();
        }
    }
}