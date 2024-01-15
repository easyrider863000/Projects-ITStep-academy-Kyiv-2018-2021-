using System.Collections.ObjectModel;

namespace Homework.Models
{
    public class Users : ObservableCollection<User>
    {
        public Users()
        {
            this.Add(new User { FirstName = "Masha", Age = 20, LastName = "Ivanova" });
            this.Add(new User { FirstName = "Dasha", Age = 20, LastName = "Ivanova" });
            this.Add(new User { FirstName = "Ivan", Age = 20, LastName = "Davidoff" });
        }
    }
}
