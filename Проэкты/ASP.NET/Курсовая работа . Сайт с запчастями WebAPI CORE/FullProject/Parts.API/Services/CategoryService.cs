using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Domain.Services;
using Parts.API.Domain.Services.Communication;

namespace Parts.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);
            if (existingCategory == null)
                return new CategoryResponse("Category not found");
            try
            {
                categoryRepository.Remove(existingCategory);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Error when deleting category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await categoryRepository.AddAsync(category);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Error when saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);
            if (existingCategory == null)
                return new CategoryResponse("Category not found");
            
            existingCategory.Name = category.Name;
            existingCategory.PhotoPath = category.PhotoPath;

            try
            {
                categoryRepository.Update(existingCategory);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Error when updating category: {ex.Message}");
            }
        }
    }
}