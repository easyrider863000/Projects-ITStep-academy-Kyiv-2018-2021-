using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Good = new HashSet<Good>();
            SupplierAddress = new HashSet<SupplierAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Good> Good { get; set; }
        public virtual ICollection<SupplierAddress> SupplierAddress { get; set; }
    }
}
