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
    public class ManufacturerController : ApiController
    {
        ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return manufacturerRepository.GetAll();
        }

        public Manufacturer GetManufacturer(int id)
        {
            return manufacturerRepository.Get(id);
        }

        [HttpPost]
        public void CreateManufacturer([FromBody]Manufacturer manufacturer)
        {
            manufacturerRepository.Add(manufacturer);
        }

        [HttpPut]
        public void EditManufacturer(int id, [FromBody]Manufacturer manufacturer)
        {
            if (id == manufacturer.ManufacturerId)
            {
                manufacturerRepository.GetDB().Entry(manufacturer).State = EntityState.Modified;
                manufacturerRepository.GetDB().SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = manufacturerRepository.Get(id);
            if (manufacturer != null)
            {
                manufacturerRepository.Delete(id);
            }
        }
    }
}
