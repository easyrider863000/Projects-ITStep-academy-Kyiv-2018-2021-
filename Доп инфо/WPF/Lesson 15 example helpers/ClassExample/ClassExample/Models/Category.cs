using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample.Models
{
    public class Category : IEquatable<Category>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public bool Equals(Category other)
        {
            return this.Id == other.Id;
        }
        public override int GetHashCode()
        {
            int hashOpCode = Id.GetHashCode() ^ this.CategoryName.GetHashCode();
            return hashOpCode;
        }
    }
}
