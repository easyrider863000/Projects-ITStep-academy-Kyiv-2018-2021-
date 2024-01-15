using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int IdStatus { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual StatusDelivery IdStatusNavigation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
