using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;
using Parts.API.Extensions;

namespace Parts.API.Services
{
    public class ClientService:IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IUnitOfWork unitOfWork;
        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            this.clientRepository = clientRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ClientResponse> DeleteAsync(int id)
        {
            var existingClient = await clientRepository.FindByIdAsync(id);
            if (existingClient == null)
                return new ClientResponse("Client not found");
            try
            {
                clientRepository.Remove(existingClient);
                await unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"Error when was deleting client: {ex.Message}");
            }
        }

        public async Task<AddressResponse> DeleteAddressAsync(int clientId, int addressId)
        {
            var existingAddress = await clientRepository.FindAddressByIdAsync(addressId);
            if (existingAddress == null)
                return new AddressResponse("Address not found");
            try
            {
                clientRepository.RemoveAddress(clientId, existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"Error when was deleting address: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Client>> ListAsync()
        {
            return await clientRepository.ListAsync();
        }

        public async Task<ClientResponse> SaveAsync(Client client)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                client.Password = MD5Hashing.GetMd5Hash(md5Hash, client.Password);
            }

            try
            {
                var cli = (await clientRepository.ListAsync()).Where(t=>t.Login==client.Login);
                if(cli.Count()>0){
                    throw new Exception("Login already exist");
                }
                await clientRepository.AddAsync(client);
                await unitOfWork.CompleteAsync();

                return new ClientResponse(client);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"Error when was saving the client: {ex.Message}");
            }
        }

        public async Task<AddressResponse> SaveAddressAsync(int id, Address address)
        {
            try
            {
                await clientRepository.AddAddressAsync(id, address);
                await unitOfWork.CompleteAsync();

                return new AddressResponse(address);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"Error when was saving the address: {ex.Message}");
            }
        }

        public async Task<ClientResponse> UpdateAsync(int id, Client client)
        {
            var existingClient = await clientRepository.FindByIdAsync(id);
            if (existingClient == null)
                return new ClientResponse("Client not found");
            existingClient.ClientAddress = client.ClientAddress;
            existingClient.Description = client.Description;
            existingClient.IdRole = client.IdRole;
            existingClient.Login = client.Login;
            using (MD5 md5Hash = MD5.Create())
            {
                existingClient.Password = MD5Hashing.GetMd5Hash(md5Hash, client.Password);
            }
            existingClient.SurName = client.SurName;
            existingClient.Name = client.Name;
            existingClient.PriceDelivery = client.PriceDelivery;
            
            try
            {
                var cli = (await clientRepository.ListAsync()).Where(t=>t.Login==existingClient.Login && t.Id!=existingClient.Id);
                if(cli.Count()>0){
                    throw new Exception("Login already exist");
                }
                clientRepository.Update(existingClient);
                await unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                return new ClientResponse($"Error when updating client: {ex.Message}");
            }
        }

        public async Task<AddressResponse> UpdateAddressAsync(int clientId, int addressId, Address address)
        {
            var existingAddress = await clientRepository.FindAddressByIdAsync(addressId);
            if (existingAddress == null)
                return new AddressResponse("Address not found");
            existingAddress.City = address.City;
            existingAddress.Country = address.Country;
            existingAddress.Description = address.Description;
            existingAddress.Flat = address.Flat;
            existingAddress.House = address.House;
            existingAddress.Street = address.Street;
            
            if((await clientRepository.GetAddressAsync(clientId)).Where(x=>x.Id==addressId).Count()<=0){
                return new AddressResponse("Address not found");
            }

            try
            {
                clientRepository.UpdateAddress(existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"Error when updating address: {ex.Message}");
            }
        }


        public async Task<IEnumerable<Address>> GetAddressAsync(int id, string login)
        {
            if(!(await IsClientSafety(id,login)))
            {
                return null;
            }
            return await clientRepository.GetAddressAsync(id);
        }
        public async Task<bool> IsClientSafety(int id, string login){
            var clients = await clientRepository.FindByIdAsync(id);
            if(clients!=null && clients.Login!=login)
            {
                return false;
            }
            return true;
        }









        public async Task<AddressPhoneNumberResponse> UpdateAddressPhoneAsync(int clientId, int addressId, int phoneId, AddressPhoneNumber address)
        {
            var existingAddress = await clientRepository.FindAddressPhoneByIdAsync(phoneId);
            if (existingAddress == null)
                return new AddressPhoneNumberResponse("Phone not found");
            existingAddress.PhoneNumber = address.PhoneNumber;
            
            if((await clientRepository.GetAddressPhoneAsync(clientId,addressId)).Where(x=>x.Id==phoneId).Count()<=0){
                return new AddressPhoneNumberResponse("Phone not found");
            }

            try
            {
                clientRepository.UpdateAddressPhone(existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressPhoneNumberResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressPhoneNumberResponse($"Error when updating phone: {ex.Message}");
            }
        }


        public async Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int clientId, int addressId, string login)
        {
            if(!(await IsClientSafety(clientId,login)))
            {
                return null;
            }
            return await clientRepository.GetAddressPhoneAsync(clientId, addressId);
        }

        public async Task<AddressPhoneNumberResponse> DeleteAddressPhoneAsync(int clientId, int addressId, int phoneId)
        {
            var existingAddress = await clientRepository.FindAddressPhoneByIdAsync(phoneId);
            if (existingAddress == null)
                return new AddressPhoneNumberResponse("Phone not found");
            try
            {
                clientRepository.RemoveAddressPhone(addressId, phoneId, existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressPhoneNumberResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressPhoneNumberResponse($"Error when was deleting phone: {ex.Message}");
            }
        }
        public async Task<AddressPhoneNumberResponse> SaveAddressPhoneAsync(int addressId, AddressPhoneNumber address)
        {
            try
            {
                await clientRepository.AddAddressPhoneAsync(addressId, address);
                await unitOfWork.CompleteAsync();

                return new AddressPhoneNumberResponse(address);
            }
            catch (Exception ex)
            {
                return new AddressPhoneNumberResponse($"Error when was saving the phone: {ex.Message}");
            }
        }









        public async Task<AddressMailResponse> UpdateAddressMailAsync(int clientId, int addressId, int mailId, AddressMail address)
        {
            var existingAddress = await clientRepository.FindAddressMailByIdAsync(mailId);
            if (existingAddress == null)
                return new AddressMailResponse("Mail not found");
            existingAddress.Mail = address.Mail;
            
            if((await clientRepository.GetAddressMailAsync(clientId,addressId)).Where(x=>x.Id==mailId).Count()<=0){
                return new AddressMailResponse("Mail not found");
            }

            try
            {
                clientRepository.UpdateAddressMail(existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressMailResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressMailResponse($"Error when updating mail: {ex.Message}");
            }
        }


        public async Task<IEnumerable<AddressMail>> GetAddressMailAsync(int clientId, int addressId, string login)
        {
            if(!(await IsClientSafety(clientId,login)))
            {
                return null;
            }
            return await clientRepository.GetAddressMailAsync(clientId, addressId);
        }

        public async Task<AddressMailResponse> DeleteAddressMailAsync(int clientId, int addressId, int mailId)
        {
            var existingAddress = await clientRepository.FindAddressMailByIdAsync(mailId);
            if (existingAddress == null)
                return new AddressMailResponse("Mail not found");
            try
            {
                clientRepository.RemoveAddressMail(addressId, mailId, existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressMailResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressMailResponse($"Error when was deleting mail: {ex.Message}");
            }
        }
        public async Task<AddressMailResponse> SaveAddressMailAsync(int addressId, AddressMail address)
        {
            try
            {
                await clientRepository.AddAddressMailAsync(addressId, address);
                await unitOfWork.CompleteAsync();

                return new AddressMailResponse(address);
            }
            catch (Exception ex)
            {
                return new AddressMailResponse($"Error when was saving the mail: {ex.Message}");
            }
        }
    }
}


