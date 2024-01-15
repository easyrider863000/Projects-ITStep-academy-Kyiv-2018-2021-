using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Address
    {
        public Address()
        {
            AddressMail = new HashSet<AddressMail>();
            AddressPhoneNumber = new HashSet<AddressPhoneNumber>();
            ClientAddress = new HashSet<ClientAddress>();
            SupplierAddress = new HashSet<SupplierAddress>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AddressMail> AddressMail { get; set; }
        public virtual ICollection<AddressPhoneNumber> AddressPhoneNumber { get; set; }
        public virtual ICollection<ClientAddress> ClientAddress { get; set; }
        public virtual ICollection<SupplierAddress> SupplierAddress { get; set; }
    }
}
