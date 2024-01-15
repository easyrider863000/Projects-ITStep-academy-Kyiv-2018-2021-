using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class SupplierAddress
    {
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        public int IdAddress { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual Supplier IdSupplierNavigation { get; set; }
    }
}
