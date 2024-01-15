using System.Collections.ObjectModel;

namespace _03._07._2019_lesson_10_MVVM.Models
{
    public class Users : ObservableCollection<User>
    {
        public Users()
        {
            this.Add(new User() { FirstName = "Masha", Age = 20, LastName = "Ivanova", Email="esrdfcgvh@gmail.com"});
            this.Add(new User() { FirstName = "Dasha", Age = 30, LastName = "Ivanova", Email = "esrsefvh@gmail.com" });
            this.Add(new User() { FirstName = "Ivan", Age = 23, LastName = "Davidow", Email = "wdfcgvh@gmail.com" });
        }
    }
}
