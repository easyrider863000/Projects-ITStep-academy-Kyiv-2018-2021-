using DAL_Paggination;
using DAL_Paggination.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }
        
        public Category GetCategory(int id)
        {
            return categoryRepository.Get(id);
        }

        [HttpPost]
        public void CreateCategory([FromBody]Category category)
        {
            categoryRepository.Add(category);
        }

        [HttpPut]
        public void EditCategory(int id,[FromBody]Category category)
        {
            if (id == category.CategoryId)
            {
                categoryRepository.GetDB().Entry(category).State = EntityState.Modified;
                categoryRepository.GetDB().SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {
            Category category = categoryRepository.Get(id);
            if (category != null)
            {
                categoryRepository.Delete(id);
            }
        }
    }
}
