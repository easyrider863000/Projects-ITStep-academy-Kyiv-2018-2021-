using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<OrderResponse> DeleteAsync(int id)
        {
            var existingOrder = await orderRepository.FindByIdAsync(id);
            if (existingOrder == null)
                return new OrderResponse("Order not found");
            try
            {
                orderRepository.Remove(existingOrder);
                await unitOfWork.CompleteAsync();

                return new OrderResponse(existingOrder);
            }
            catch (Exception ex)
            {
                return new OrderResponse($"Error when deleting order: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
            return await orderRepository.ListAsync();
        }

        public async Task<OrderResponse> SaveAsync(Order order)
        {
            try
            {
                await orderRepository.AddAsync(order);
                await unitOfWork.CompleteAsync();

                return new OrderResponse(order);
            }
            catch (Exception ex)
            {
                return new OrderResponse($"Error when saving the order: {ex.Message}");
            }
        }

        public async Task<OrderResponse> UpdateAsync(int id, Order order)
        {
            var existingOrder = await orderRepository.FindByIdAsync(id);
            if (existingOrder == null)
                return new OrderResponse("Order not found");
            
            existingOrder.Count = order.Count;
            existingOrder.IdClient = order.IdClient;
            existingOrder.IdGood = order.IdGood;
            existingOrder.IdOrderDetails = order.IdOrderDetails;

            try
            {
                orderRepository.Update(existingOrder);
                await unitOfWork.CompleteAsync();

                return new OrderResponse(existingOrder);
            }
            catch (Exception ex)
            {
                return new OrderResponse($"Error when updating order: {ex.Message}");
            }
        }
    }
}