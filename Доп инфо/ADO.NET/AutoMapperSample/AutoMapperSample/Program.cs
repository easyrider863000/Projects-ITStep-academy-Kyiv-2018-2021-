using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperSample
{
    class Good
    {
        public int Id { get; set; }
        public string GoodName { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int Price { get; set; }

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }

        public override string ToString()
        {
            return $"{Id} {GoodName} {Price} {CategoryId} {ManufacturerId} {A} {B} {C} {D}";
        }

    }


    class GoodDTO
    {
        public int Id { get; set; }
        public string NazvanieTovara { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Id} {NazvanieTovara} {Price} {CategoryId} {ManufacturerId}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Good, GoodDTO>().ForMember("NazvanieTovara", x => x.MapFrom(y => y.GoodName));
                cfg.CreateMap<GoodDTO, Good>().ForMember("GoodName", x => x.MapFrom(y => y.NazvanieTovara));
            });
            var mapper = config.CreateMapper();
            Good good = new Good
            {
                Id = 1,
                GoodName = "Good1",
                Price = 10,
                CategoryId = 2,
                ManufacturerId = 3,
                A = 1,
                B = 2,
                C = 3,
                D = 4
            };

            GoodDTO dto = mapper.Map<GoodDTO>(good);
            Console.WriteLine(dto);

            Good good1 = mapper.Map<Good>(dto);

            Console.WriteLine(good1);

            //Console.WriteLine(dto);


           


        }
    }
}
