using DAL_Paggination.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Paggination.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        ShopADO db;
        public ManufacturerRepository()
        {
            db = new ShopADO();
        }
        public Manufacturer Get(int id)
        {
            return db.Manufacturer.Find(id);
        }
        public IEnumerable<Manufacturer> GetAll()
        {
            return db.Manufacturer;
        }
        public void Delete(int id)
        {
            Manufacturer manufacturer = this.Get(id);
            db.Manufacturer.Remove(manufacturer);
            db.SaveChanges();
        }
        public void Update(Manufacturer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Create(Manufacturer obj)
        {
            db.Manufacturer.Add(obj);
            db.SaveChanges();
        }
    }
}
