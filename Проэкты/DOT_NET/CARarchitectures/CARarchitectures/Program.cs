using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARarchitectures
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CarsArchitecureEntities1())
            {
                var std = new PhotoDB()
                {
                    PhotoPath = "/Images/12.jpg",
                    CarId=13
                };
                context.PhotoDB.Add(std);
                context.SaveChanges();
            }
        }
    }
}
