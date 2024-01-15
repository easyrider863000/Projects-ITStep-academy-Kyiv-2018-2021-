using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Services
{
    public class StatusDeliveryService : IStatusDeliveryService
    {
        private readonly IStatusDeliveryRepository statusDeliveryRepository;
        private readonly IUnitOfWork unitOfWork;
        public StatusDeliveryService(IStatusDeliveryRepository statusDeliveryRepository, IUnitOfWork unitOfWork)
        {
            this.statusDeliveryRepository = statusDeliveryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<StatusDeliveryResponse> DeleteAsync(int id)
        {
            var existingStatusDelivery = await statusDeliveryRepository.FindByIdAsync(id);
            if (existingStatusDelivery == null)
                return new StatusDeliveryResponse("StatusDelivery not found");
            try
            {
                statusDeliveryRepository.Remove(existingStatusDelivery);
                await unitOfWork.CompleteAsync();

                return new StatusDeliveryResponse(existingStatusDelivery);
            }
            catch (Exception ex)
            {
                return new StatusDeliveryResponse($"Error when deleting statusDelivery: {ex.Message}");
            }
        }

        public async Task<IEnumerable<StatusDelivery>> ListAsync()
        {
            return await statusDeliveryRepository.ListAsync();
        }

        public async Task<StatusDeliveryResponse> SaveAsync(StatusDelivery statusDelivery)
        {
            try
            {
                await statusDeliveryRepository.AddAsync(statusDelivery);
                await unitOfWork.CompleteAsync();

                return new StatusDeliveryResponse(statusDelivery);
            }
            catch (Exception ex)
            {
                return new StatusDeliveryResponse($"Error when saving the statusDelivery: {ex.Message}");
            }
        }

        public async Task<StatusDeliveryResponse> UpdateAsync(int id, StatusDelivery statusDelivery)
        {
            var existingStatusDelivery = await statusDeliveryRepository.FindByIdAsync(id);
            if (existingStatusDelivery == null)
                return new StatusDeliveryResponse("StatusDelivery not found");
            
            existingStatusDelivery.Name = statusDelivery.Name;
            existingStatusDelivery.Description = statusDelivery.Description;

            try
            {
                statusDeliveryRepository.Update(existingStatusDelivery);
                await unitOfWork.CompleteAsync();

                return new StatusDeliveryResponse(existingStatusDelivery);
            }
            catch (Exception ex)
            {
                return new StatusDeliveryResponse($"Error when updating statusDelivery: {ex.Message}");
            }
        }
    }
}