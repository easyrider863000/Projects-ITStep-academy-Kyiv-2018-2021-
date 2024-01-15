using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class StatusDelivery
    {
        public StatusDelivery()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
