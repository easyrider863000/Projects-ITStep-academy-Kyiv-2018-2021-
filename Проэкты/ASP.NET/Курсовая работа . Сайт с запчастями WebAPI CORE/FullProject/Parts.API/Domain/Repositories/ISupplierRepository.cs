using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> ListAsync();
        Task AddAsync(Supplier supplier);
        Task AddAddressAsync(int id, Address address);
        void Update(Supplier supplier);
        void UpdateAddress(Address address);
        Task<Supplier> FindByIdAsync(int id);
        void Remove(Supplier supplier);
        void RemoveAddress(int supplierId, Address address);
        Task<Address> FindAddressByIdAsync(int id);
        Task<IEnumerable<Address>> GetAddressAsync(int supplierId);


        
        Task AddAddressMailAsync(int addressId, AddressMail address);
        Task<AddressMail> FindAddressMailByIdAsync(int id);
        void UpdateAddressMail(AddressMail address);
        Task<IEnumerable<AddressMail>> GetAddressMailAsync(int supplierId, int addressId);
        void RemoveAddressMail(int addressId, int mailId, AddressMail address);


        
        Task AddAddressPhoneAsync(int addressId, AddressPhoneNumber address);
        Task<AddressPhoneNumber> FindAddressPhoneByIdAsync(int id);
        void UpdateAddressPhone(AddressPhoneNumber address);
        Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int supplierId, int addressId);
        void RemoveAddressPhone(int addressId, int phoneId, AddressPhoneNumber address);
    }
}