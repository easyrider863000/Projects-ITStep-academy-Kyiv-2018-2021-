using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IUnitOfWork unitOfWork;
        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SupplierResponse> DeleteAsync(int id)
        {
            var existingSupplier = await supplierRepository.FindByIdAsync(id);
            if (existingSupplier == null)
                return new SupplierResponse("Supplier not found");
            try
            {
                supplierRepository.Remove(existingSupplier);
                await unitOfWork.CompleteAsync();

                return new SupplierResponse(existingSupplier);
            }
            catch (Exception ex)
            {
                return new SupplierResponse($"Error when deleting supplier: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await supplierRepository.ListAsync();
        }

        public async Task<SupplierResponse> SaveAsync(Supplier supplier)
        {
            try
            {
                await supplierRepository.AddAsync(supplier);
                await unitOfWork.CompleteAsync();

                return new SupplierResponse(supplier);
            }
            catch (Exception ex)
            {
                return new SupplierResponse($"Error when saving the supplier: {ex.Message}");
            }
        }

        public async Task<SupplierResponse> UpdateAsync(int id, Supplier supplier)
        {
            var existingSupplier = await supplierRepository.FindByIdAsync(id);
            if (existingSupplier == null)
                return new SupplierResponse("Supplier not found");
            
            existingSupplier.Name = supplier.Name;
            existingSupplier.Description = supplier.Description;

            try
            {
                supplierRepository.Update(existingSupplier);
                await unitOfWork.CompleteAsync();

                return new SupplierResponse(existingSupplier);
            }
            catch (Exception ex)
            {
                return new SupplierResponse($"Error when updating supplier: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Address>> GetAddressAsync(int id)
        {
            return await supplierRepository.GetAddressAsync(id);
        }

        public async Task<AddressResponse> UpdateAddressAsync(int supplierId, int addressId, Address address)
        {
            var existingAddress = await supplierRepository.FindAddressByIdAsync(addressId);
            if (existingAddress == null)
                return new AddressResponse("Address not found");
            existingAddress.City = address.City;
            existingAddress.Country = address.Country;
            existingAddress.Description = address.Description;
            existingAddress.Flat = address.Flat;
            existingAddress.House = address.House;
            existingAddress.Street = address.Street;
            
            if((await supplierRepository.GetAddressAsync(supplierId)).Where(x=>x.Id==addressId).Count()<=0){
                return new AddressResponse("Address not found");
            }

            try
            {
                supplierRepository.UpdateAddress(existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"Error when updating address: {ex.Message}");
            }
        }

        public async Task<AddressResponse> DeleteAddressAsync(int clientId, int addressId)
        {
            var existingAddress = await supplierRepository.FindAddressByIdAsync(addressId);
            if (existingAddress == null)
                return new AddressResponse("Address not found");
            try
            {
                supplierRepository.RemoveAddress(clientId, existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"Error when was deleting address: {ex.Message}");
            }
        }

        public async Task<AddressResponse> SaveAddressAsync(int id, Address address)
        {
            try
            {
                await supplierRepository.AddAddressAsync(id, address);
                await unitOfWork.CompleteAsync();

                return new AddressResponse(address);
            }
            catch (Exception ex)
            {
                return new AddressResponse($"Error when was saving the address: {ex.Message}");
            }
        }






        public async Task<IEnumerable<AddressMail>> GetAddressMailAsync(int supplierId, int addressId)
        {
            return await supplierRepository.GetAddressMailAsync(supplierId, addressId);
        }

        public async Task<AddressMailResponse> UpdateAddressMailAsync(int supplierId, int addressId, int mailId, AddressMail address)
        {
            var existingAddress = await supplierRepository.FindAddressMailByIdAsync(mailId);
            if (existingAddress == null)
                return new AddressMailResponse("Mail not found");
            existingAddress.Mail = address.Mail;
            
            if((await supplierRepository.GetAddressMailAsync(supplierId, addressId)).Where(x=>x.Id==mailId).Count()<=0){
                return new AddressMailResponse("Mail not found");
            }

            try
            {
                supplierRepository.UpdateAddressMail(existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressMailResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressMailResponse($"Error when updating mail: {ex.Message}");
            }
        }

        public async Task<AddressMailResponse> DeleteAddressMailAsync(int addressId, int mailId)
        {
            var existingAddress = await supplierRepository.FindAddressMailByIdAsync(mailId);
            if (existingAddress == null)
                return new AddressMailResponse("Mail not found");
            try
            {
                supplierRepository.RemoveAddressMail(addressId, mailId, existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressMailResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressMailResponse($"Error when was deleting mail: {ex.Message}");
            }
        }

        public async Task<AddressMailResponse> SaveAddressMailAsync(int id, AddressMail address)
        {
            try
            {
                await supplierRepository.AddAddressMailAsync(id, address);
                await unitOfWork.CompleteAsync();

                return new AddressMailResponse(address);
            }
            catch (Exception ex)
            {
                return new AddressMailResponse($"Error when was saving the mail: {ex.Message}");
            }
        }






        public async Task<IEnumerable<AddressPhoneNumber>> GetAddressPhoneAsync(int supplierId, int addressId)
        {
            return await supplierRepository.GetAddressPhoneAsync(supplierId, addressId);
        }

        public async Task<AddressPhoneNumberResponse> UpdateAddressPhoneAsync(int supplierId, int addressId, int phoneId, AddressPhoneNumber address)
        {
            var existingAddress = await supplierRepository.FindAddressPhoneByIdAsync(phoneId);
            if (existingAddress == null)
                return new AddressPhoneNumberResponse("Phone not found");
            existingAddress.PhoneNumber = address.PhoneNumber;
            
            if((await supplierRepository.GetAddressPhoneAsync(supplierId, addressId)).Where(x=>x.Id==phoneId).Count()<=0){
                return new AddressPhoneNumberResponse("Phone not found");
            }

            try
            {
                supplierRepository.UpdateAddressPhone(existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressPhoneNumberResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressPhoneNumberResponse($"Error when updating phone: {ex.Message}");
            }
        }

        public async Task<AddressPhoneNumberResponse> DeleteAddressPhoneAsync(int addressId, int phoneId)
        {
            var existingAddress = await supplierRepository.FindAddressPhoneByIdAsync(phoneId);
            if (existingAddress == null)
                return new AddressPhoneNumberResponse("Phone not found");
            try
            {
                supplierRepository.RemoveAddressPhone(addressId, phoneId, existingAddress);
                await unitOfWork.CompleteAsync();

                return new AddressPhoneNumberResponse(existingAddress);
            }
            catch (Exception ex)
            {
                return new AddressPhoneNumberResponse($"Error when was deleting phone: {ex.Message}");
            }
        }

        public async Task<AddressPhoneNumberResponse> SaveAddressPhoneAsync(int id, AddressPhoneNumber address)
        {
            try
            {
                await supplierRepository.AddAddressPhoneAsync(id, address);
                await unitOfWork.CompleteAsync();

                return new AddressPhoneNumberResponse(address);
            }
            catch (Exception ex)
            {
                return new AddressPhoneNumberResponse($"Error when was saving the phone: {ex.Message}");
            }
        }
    }
}