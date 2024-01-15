using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.API.Domain.Models;
using Shop.API.Domain.Repositories;
using Shop.API.Domain.Services;
using Shop.API.Domain.Services.Communication;

namespace Shop.API.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository manufacturerRepository;
        private readonly IUnitOfWork unitOfWork;
        public ManufacturerService(IManufacturerRepository manufacturerRepository, IUnitOfWork unitOfWork)
        {
            this.manufacturerRepository = manufacturerRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ManufacturerResponse> DeleteAsync(int id)
        {
            var existingManufacturer = await manufacturerRepository.FindByIdAsync(id);
            if (existingManufacturer == null)
                return new ManufacturerResponse("Manufacturer not found");
            try
            {
                manufacturerRepository.Remove(existingManufacturer);
                await unitOfWork.CompleteAsync();

                return new ManufacturerResponse(existingManufacturer);
            }
            catch (Exception ex)
            {
                return new ManufacturerResponse($"Error when deleting manufacturer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Manufacturer>> ListAsync()
        {
            return await manufacturerRepository.ListAsync();
        }

        public async Task<ManufacturerResponse> SaveAsync(Manufacturer manufacturer)
        {
            try
            {
                await manufacturerRepository.AddAsync(manufacturer);
                await unitOfWork.CompleteAsync();

                return new ManufacturerResponse(manufacturer);
            }
            catch (Exception ex)
            {
                return new ManufacturerResponse($"Error when saving the manufacturer: {ex.Message}");
            }
        }

        public async Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer)
        {
            var existingManufacturer = await manufacturerRepository.FindByIdAsync(id);
            if (existingManufacturer == null)
                return new ManufacturerResponse("Manufacturer not found");
            
            existingManufacturer.Name = manufacturer.Name;

            try
            {
                manufacturerRepository.Update(existingManufacturer);
                await unitOfWork.CompleteAsync();

                return new ManufacturerResponse(existingManufacturer);
            }
            catch (Exception ex)
            {
                return new ManufacturerResponse($"Error when updating manufacturer: {ex.Message}");
            }
        }
    }
}