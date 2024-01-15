using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsRepository orderDetailsRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderDetailsService(IOrderDetailsRepository orderDetailsRepository, IUnitOfWork unitOfWork)
        {
            this.orderDetailsRepository = orderDetailsRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderDetailsResponse> DeleteAsync(int id)
        {
            var existingOrderDetails = await orderDetailsRepository.FindByIdAsync(id);
            if (existingOrderDetails == null)
                return new OrderDetailsResponse("OrderDetails not found");
            try
            {
                orderDetailsRepository.Remove(existingOrderDetails);
                await unitOfWork.CompleteAsync();

                return new OrderDetailsResponse(existingOrderDetails);
            }
            catch (Exception ex)
            {
                return new OrderDetailsResponse($"Error when deleting orderDetails: {ex.Message}");
            }
        }

        public async Task<IEnumerable<OrderDetails>> ListAsync()
        {
            return await orderDetailsRepository.ListAsync();
        }

        public async Task<OrderDetailsResponse> SaveAsync(OrderDetails orderDetails)
        {
            try
            {
                await orderDetailsRepository.AddAsync(orderDetails);
                await unitOfWork.CompleteAsync();

                return new OrderDetailsResponse(orderDetails);
            }
            catch (Exception ex)
            {
                return new OrderDetailsResponse($"Error when saving the orderDetails: {ex.Message}");
            }
        }

        public async Task<OrderDetailsResponse> UpdateAsync(int id, OrderDetails orderDetails)
        {
            var existingOrderDetails = await orderDetailsRepository.FindByIdAsync(id);
            if (existingOrderDetails == null)
                return new OrderDetailsResponse("OrderDetails not found");
            
            existingOrderDetails.IdStatus = orderDetails.IdStatus;
            existingOrderDetails.OrderDate = orderDetails.OrderDate;

            try
            {
                orderDetailsRepository.Update(existingOrderDetails);
                await unitOfWork.CompleteAsync();

                return new OrderDetailsResponse(existingOrderDetails);
            }
            catch (Exception ex)
            {
                return new OrderDetailsResponse($"Error when updating orderDetails: {ex.Message}");
            }
        }
    }
}