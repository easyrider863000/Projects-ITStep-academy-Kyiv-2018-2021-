using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Good
    {
        public Good()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int IdManufacturer { get; set; }
        public int IdCategory { get; set; }
        public int IdSupplier { get; set; }
        public decimal Price { get; set; }
        public bool? IsBeating { get; set; }
        public bool? IsLiquid { get; set; }
        public string PhotoPath { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual Manufacturer IdManufacturerNavigation { get; set; }
        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
