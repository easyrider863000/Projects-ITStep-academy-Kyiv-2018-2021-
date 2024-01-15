using System.Linq;
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
            CreateMap<SaveUserResource, User>();
                            // .ForMember(dest => dest.Role, src => src.MapFrom(x => x.UserRoles.Select(y => y.Role.Name)));
            CreateMap<SaveRoleResource, Role>();
        }
    }
}