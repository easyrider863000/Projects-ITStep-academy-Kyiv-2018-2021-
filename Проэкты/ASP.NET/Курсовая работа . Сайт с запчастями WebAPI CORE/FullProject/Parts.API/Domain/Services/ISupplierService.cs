using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task<SupplierResponse> SaveAsync(Supplier supplier);
        Task<AddressResponse> SaveAddressAsync(int id, Address address);
        Task<SupplierResponse> UpdateAsync(int id, Supplier supplier);
        Task<AddressResponse> UpdateAddressAsync(int supplierId, int addressId, Address address);
        Task<SupplierResponse> DeleteAsync(int id);
        Task<IEnumerable<Address>> GetAddressAsync(int id);
        Task<AddressResponse> DeleteAddressAsync(int supplierId, int addressId);

        
        Task<IEnumerable<AddressMail>> GetAddressMailAsync(int supplierId, int addressId);
        Task<AddressMailResponse> UpdateAddressMailAsync(int supplierId, int addressId, int mailId, AddressMail address);
        Task<AddressMailResponse> DeleteAddressMailAsync(int addressId, int mailId);
        Task<AddressMailResponse> SaveAddressMailAsync(int id, AddressMail address);

        
        Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int supplierId, int addressId);
        Task<AddressPhoneNumberResponse> UpdateAddressPhoneAsync(int supplierId, int addressId, int phoneId, AddressPhoneNumber address);
        Task<AddressPhoneNumberResponse> DeleteAddressPhoneAsync(int addressId, int phoneId);
        Task<AddressPhoneNumberResponse> SaveAddressPhoneAsync(int id, AddressPhoneNumber address);
    }
}