using DAL_Paggination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Paggination.Repositories
{
    public class CategoryRepository:IRepository<Category>
    {
        ShopADO db;
        public CategoryRepository()
        {
            db = new ShopADO();
        }
        public Category Get(int id)
        {
            return db.Category.Find(id);
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }
        public void Delete(int id)
        {
            Category category = this.Get(id);
            db.Category.Remove(category);
            db.SaveChanges();
        }
    }
}
