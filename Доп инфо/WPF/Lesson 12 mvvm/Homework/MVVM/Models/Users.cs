using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class Users : ObservableCollection<User>
    {
        public Users()
        {
            this.Add(new User { FirstName = "Masha", Age = 20, LastName = "Ivanova", HireDate = DateTime.Now });
            this.Add(new User { FirstName = "Dasha", Age = 20, LastName = "Ivanova", HireDate = DateTime.Now });
            this.Add(new User { FirstName = "Ivan", Age = 20, LastName = "Davidoff", HireDate = DateTime.Now });
        }
    }
}
