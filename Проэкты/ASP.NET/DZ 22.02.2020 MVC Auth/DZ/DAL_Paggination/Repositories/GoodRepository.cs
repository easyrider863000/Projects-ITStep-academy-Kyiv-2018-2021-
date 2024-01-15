using DAL_Paggination.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Paggination.Repositories
{
    public class GoodRepository : IRepository<Good>
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
        public void Update(Good obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Create(Good obj)
        {
            db.Good.Add(obj);
            db.SaveChanges();
        }
    }
}
