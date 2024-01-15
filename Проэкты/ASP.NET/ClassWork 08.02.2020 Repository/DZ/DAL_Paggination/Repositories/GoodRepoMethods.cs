using DAL_Paggination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Paggination.Repositories
{
    public abstract class GoodRepoMethods
    {
        public static bool IsInvolvedCategory(IRepository<Good> repo,int id)
        {
            if ((from good in repo.GetAll()
                 where good.CategoryId == id
                 select good).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
        public static bool IsInvolvedManufacturer(IRepository<Good> repo, int id)
        {
            if ((from good in repo.GetAll()
                 where good.ManufacturerId == id
                 select good).FirstOrDefault() != null)
                return true;
            else
                return false;
        }
    }
}
