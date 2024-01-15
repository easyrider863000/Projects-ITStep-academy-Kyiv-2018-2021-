using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdGood { get; set; }
        public decimal? Count { get; set; }
        public int IdOrderDetails { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Good IdGoodNavigation { get; set; }
        public virtual OrderDetails IdOrderDetailsNavigation { get; set; }
    }
}
