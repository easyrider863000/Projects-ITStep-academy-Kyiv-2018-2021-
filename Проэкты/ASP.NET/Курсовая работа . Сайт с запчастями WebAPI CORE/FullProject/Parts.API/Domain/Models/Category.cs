using System;
using System.Collections.Generic;

namespace Parts.API.Domain.Models
{
    public partial class Category
    {
        public Category()
        {
            Good = new HashSet<Good>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<Good> Good { get; set; }
    }
}
