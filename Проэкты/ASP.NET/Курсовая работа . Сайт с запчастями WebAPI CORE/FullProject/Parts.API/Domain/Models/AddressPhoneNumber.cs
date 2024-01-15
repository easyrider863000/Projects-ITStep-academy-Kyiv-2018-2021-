using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class AddressPhoneNumber
    {
        public int Id { get; set; }
        public int IdAddress { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Address IdAddressNavigation { get; set; }
    }
}
