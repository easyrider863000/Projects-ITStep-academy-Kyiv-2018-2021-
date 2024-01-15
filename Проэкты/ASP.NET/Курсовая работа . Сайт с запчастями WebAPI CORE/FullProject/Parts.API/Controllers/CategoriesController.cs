using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Parts.API.Domain.Services;
using Parts.API.Resources;
using Parts.API.Domain.Models;
using Parts.API.Extensions;

namespace Parts.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseData> GetAllAsync() 
        {
            var categories = await categoryService.ListAsync();
            var resource = mapper.Map<IEnumerable<Category>,IEnumerable<CategoryResource>>(categories);
            var result = new ResponseData
            {
                Data = resource,
                Success = true,
                Message = ""
            };
            return result;
        }
        [Authorize (Roles="admin, manager, director")]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<SaveCategoryResource, Category>(resource);
            var categoryResponse = await categoryService.SaveAsync(category);  
            var categoryResource = mapper.Map<Category, CategoryResource>(categoryResponse.Category);
            var result = new ResponseData
            {
                Data = categoryResource,
                Message = categoryResponse.Message,
                Success = categoryResponse.Success
            };
            return Ok(result);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        [Authorize (Roles="admin, manager, director")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await categoryService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            
            var categoryResource = mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
}