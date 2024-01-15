using AutoMapper;
using Parts.API.Domain.Models;
using Parts.API.Resources;
using Parts.API.Resources.SaveResource;

namespace Parts.API.Mapping
{
    public class ResourceToModelProfile:Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AuthClientResource, Client>();
            CreateMap<SaveManufacturerResource, Manufacturer>();
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveClientResource, Client>();
            CreateMap<SaveSupplierResource, Supplier>();
            CreateMap<SaveStatusDeliveryResource, StatusDelivery>();
            CreateMap<SaveGoodResource, Good>();
            CreateMap<SaveOrderResource, Order>();
            CreateMap<SaveOrderDetailsResource, OrderDetails>();
            CreateMap<SaveAddressResource, Address>();
            CreateMap<SaveAddressPhoneNumberResource, AddressPhoneNumber>();
            CreateMap<SaveAddressMailResource, AddressMail>();
        }
    }
}