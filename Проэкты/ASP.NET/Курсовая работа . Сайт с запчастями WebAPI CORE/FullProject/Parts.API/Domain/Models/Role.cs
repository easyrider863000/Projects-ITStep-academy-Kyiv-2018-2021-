using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Role
    {
        public Role()
        {
            Client = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
