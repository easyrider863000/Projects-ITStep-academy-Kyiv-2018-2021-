using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.BLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string ImageURL { get; set; }
 
    }
}
