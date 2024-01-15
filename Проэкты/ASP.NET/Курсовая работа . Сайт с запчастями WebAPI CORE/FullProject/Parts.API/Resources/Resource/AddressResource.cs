using System.Collections.Generic;
using Parts.API.Domain.Models;

namespace Parts.API.Resources.Resource
{
    public class AddressResource
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string Description { get; set; }
    }
}