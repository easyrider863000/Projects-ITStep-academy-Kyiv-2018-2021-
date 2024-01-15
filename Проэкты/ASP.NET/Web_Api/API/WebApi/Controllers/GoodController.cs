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
    public class GoodController : ApiController
    {
        GoodRepository goodRepository = new GoodRepository();
        public IEnumerable<Good> GetGoods()
        {
            return goodRepository.GetAll();
        }

        public Good GetGood(int id)
        {
            return goodRepository.Get(id);
        }

        [HttpPost]
        public void CreateGood([FromBody]Good good)
        {
            goodRepository.Add(good);
        }

        [HttpPut]
        public void EditGood(int id, [FromBody]Good good)
        {
            if (id == good.GoodId)
            {
                goodRepository.GetDB().Entry(good).State = EntityState.Modified;
                goodRepository.GetDB().SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteGood(int id)
        {
            Good good = goodRepository.Get(id);
            if (good != null)
            {
                goodRepository.Delete(id);
            }
        }
    }
}
