using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_INotifyPropertyChanged.Models
{
    public class Users : ObservableCollection<User>
    {
        public Users()
        {
            this.Add(new User("Vasja", 22));
            this.Add(new User("Masha", 23));
            this.Add(new User("Dasha", 19));
        }
    }
}
