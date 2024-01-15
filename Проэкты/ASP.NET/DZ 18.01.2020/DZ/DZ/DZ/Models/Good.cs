using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DZ.Models
{
    public class Good
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int? ManufacturerId { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal GoodCount { get; set; }
    }
}