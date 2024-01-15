using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Services
{
    public class GoodService : IGoodService
    {
        private readonly IGoodRepository goodRepository;
        private readonly IUnitOfWork unitOfWork;
        public GoodService(IGoodRepository goodRepository, IUnitOfWork unitOfWork)
        {
            this.goodRepository = goodRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GoodResponse> DeleteAsync(int id)
        {
            var existingGood = await goodRepository.FindByIdAsync(id);
            if (existingGood == null)
                return new GoodResponse("Good not found");
            try
            {
                goodRepository.Remove(existingGood);
                await unitOfWork.CompleteAsync();

                return new GoodResponse(existingGood);
            }
            catch (Exception ex)
            {
                return new GoodResponse($"Error when deleting good: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Good>> ListAsync()
        {
            return await goodRepository.ListAsync();
        }

        public async Task<GoodResponse> SaveAsync(Good good)
        {
            try
            {
                await goodRepository.AddAsync(good);
                await unitOfWork.CompleteAsync();

                return new GoodResponse(good);
            }
            catch (Exception ex)
            {
                return new GoodResponse($"Error when saving the good: {ex.Message}");
            }
        }

        public async Task<GoodResponse> UpdateAsync(int id, Good good)
        {
            var existingGood = await goodRepository.FindByIdAsync(id);
            if (existingGood == null)
                return new GoodResponse("Good not found");
            
            existingGood.Name = good.Name;
            existingGood.Number = good.Number;
            existingGood.Price = good.Price;

            existingGood.IdCategory = good.IdCategory;
            existingGood.IdManufacturer = good.IdManufacturer;
            existingGood.IdSupplier = good.IdSupplier;
            existingGood.Description = good.Description;
            existingGood.IsBeating = good.IsBeating;
            existingGood.IsLiquid = good.IsLiquid;
            existingGood.PhotoPath = good.PhotoPath;            

            //
            //
            //
            //
            //
            //

            try
            {
                goodRepository.Update(existingGood);
                await unitOfWork.CompleteAsync();

                return new GoodResponse(existingGood);
            }
            catch (Exception ex)
            {
                return new GoodResponse($"Error when updating good: {ex.Message}");
            }
        }
    }
}