using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class ClientAddress
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdAddress { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
        public virtual Client IdClientNavigation { get; set; }
    }
}
