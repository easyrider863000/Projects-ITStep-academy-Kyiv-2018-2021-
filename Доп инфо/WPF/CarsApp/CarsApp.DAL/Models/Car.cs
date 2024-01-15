using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string ImageURL { get; set; }
        public static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Model = "Honda Accord",
                    Color = "Black",
                    Year = 2012,
                    ImageURL = "https://cdn2.riastatic.com/photos/ir/new/auto/photo/honda_accord__297499322-620x415x70.jpg"
                },
                new Car
                {
                    Id = 2,
                    Model = "Lada 2107",
                    Color = "Yellow",
                    Year = 1995,
                    ImageURL = "https://bumper.guru/wp-content/uploads/2019/06/post_5cf65b5785248.jpg"
                },
                new Car
                {
                    Id = 3,
                    Model = "Mercedes E220",
                    Color = "Black",
                    Year = 2012,
                    ImageURL = "https://autovolostorage.blob.core.windows.net/advertimages-6048238/mercedes-e-class-2012-030l.jpg"
                },
                new Car
                {
                    Id = 4,
                    Model = "Mitsubishi Lancer Evo 6",
                    Color = "Black",
                    Year = 2002,
                    ImageURL = "https://i.ebayimg.com/00/s/NzY4WDEwMjQ=/z/DG0AAOSwTGVbtmM1/$_86.JPG"

                },
                new Car
                {
                    Id = 5,
                    Model = "Nissan Skyline R34",
                    Color = "Gray",
                    Year = 2002,
                    ImageURL = "https://i.pinimg.com/originals/f8/bc/5c/f8bc5c1aa941b51289632a0c1cfc9d4d.jpg"
                }
            };
        }
    }
}
