using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;

namespace Parts.API.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
        Task AddAsync(Client client);
        Task AddAddressAsync(int id, Address address);
        void Update(Client client);
        void UpdateAddress(Address address);
        Task<Client> FindByIdAsync(int id);
        void Remove(Client client);
        void RemoveAddress(int clientId, Address address);
        Task<Address> FindAddressByIdAsync(int id);
        Task<Role> GetRole(int clientId);
        Task<IEnumerable<Address>> GetAddressAsync(int clientId);


        Task AddAddressPhoneAsync(int addressId, AddressPhoneNumber address);
        Task<AddressPhoneNumber> FindAddressPhoneByIdAsync(int id);
        void UpdateAddressPhone(AddressPhoneNumber address);
        Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int clientId, int addressId);
        void RemoveAddressPhone(int addressId, int phoneId, AddressPhoneNumber address);


        Task AddAddressMailAsync(int addressId, AddressMail address);
        Task<AddressMail> FindAddressMailByIdAsync(int id);
        void UpdateAddressMail(AddressMail address);
        Task<IEnumerable<AddressMail>> GetAddressMailAsync(int clientId, int addressId);
        void RemoveAddressMail(int addressId, int mailId, AddressMail address);
    }
}