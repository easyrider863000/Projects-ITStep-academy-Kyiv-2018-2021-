using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientAddress = new HashSet<ClientAddress>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Description { get; set; }
        public double? PriceDelivery { get; set; }
        public string Token { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<ClientAddress> ClientAddress { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
