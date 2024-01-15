using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Paggination.Repositories
{
    public class GoodRepository
    {
        ShopADO db;
        public GoodRepository()
        {
            db = new ShopADO();
        }
        public Good Get(int id)
        {
            return db.Good.Find(id);
        }
        public IEnumerable<Good> GetAll()
        {
            return db.Good;
        }
        public void Delete(int id)
        {
            Good good = this.Get(id);
            db.Good.Remove(good);
            db.SaveChanges();
        }
        public bool IsInvolvedCategory(int id)
        {
            if ((from good in db.Good
                 where good.CategoryId == id
                 select good).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
        public bool IsInvolvedManufacturer(int id)
        {
            if ((from good in db.Good
                 where good.ManufacturerId == id
                 select good).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
        public ShopADO GetDB()
        {
            return db;
        }
        public void Add(Good good)
        {
            db.Good.Add(good);
        }
    }
}
