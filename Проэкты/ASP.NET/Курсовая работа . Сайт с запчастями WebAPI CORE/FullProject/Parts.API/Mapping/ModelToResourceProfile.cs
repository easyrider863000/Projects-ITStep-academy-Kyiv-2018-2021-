using AutoMapper;
using Parts.API.Domain.Models;
using Parts.API.Resources;
using Parts.API.Resources.Resource;

namespace Parts.API.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Manufacturer, ManufacturerResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Client, ClientResource>();
            CreateMap<Supplier, SupplierResource>();
            CreateMap<Role, RoleResource>();
            CreateMap<StatusDelivery, StatusDeliveryResource>();
            CreateMap<Good, GoodResource>();
            CreateMap<Order, OrderResource>();
            CreateMap<OrderDetails, OrderDetailsResource>();
            CreateMap<Address, AddressResource>();
            CreateMap<AddressPhoneNumber, AddressPhoneNumberResource>();
            CreateMap<AddressMail, AddressMailResource>();
        }
    }
}