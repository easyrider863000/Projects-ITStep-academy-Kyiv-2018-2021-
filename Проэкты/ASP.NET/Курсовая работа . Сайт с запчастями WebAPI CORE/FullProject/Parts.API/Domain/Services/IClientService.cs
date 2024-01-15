using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ListAsync();
        Task<ClientResponse> SaveAsync(Client client);
        Task<AddressResponse> SaveAddressAsync(int id, Address address);
        Task<ClientResponse> UpdateAsync(int id, Client client);
        Task<AddressResponse> UpdateAddressAsync(int clientId, int addressId, Address address);
        Task<ClientResponse> DeleteAsync(int id);
        Task<IEnumerable<Address>> GetAddressAsync(int id, string login);
        Task<bool> IsClientSafety(int id, string login);
        Task<AddressResponse> DeleteAddressAsync(int clientId, int addressId);

        Task<AddressPhoneNumberResponse> UpdateAddressPhoneAsync(int clientId, int addressId, int phoneId, AddressPhoneNumber address);
        Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int clientId, int addressId, string login);
        Task<AddressPhoneNumberResponse> DeleteAddressPhoneAsync(int clientId, int addressId, int phoneId);
        Task<AddressPhoneNumberResponse> SaveAddressPhoneAsync(int addressId, AddressPhoneNumber address);

        Task<AddressMailResponse> UpdateAddressMailAsync(int clientId, int addressId, int mailId, AddressMail address);
        Task<IEnumerable<AddressMail>> GetAddressMailAsync(int clientId, int addressId, string login);
        Task<AddressMailResponse> DeleteAddressMailAsync(int clientId, int addressId, int mailId);
        Task<AddressMailResponse> SaveAddressMailAsync(int addressId, AddressMail address);
    }
}