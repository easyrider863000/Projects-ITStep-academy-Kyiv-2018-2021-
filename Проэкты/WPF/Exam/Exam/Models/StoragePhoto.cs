using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class StoragePhoto:ObservableCollection<AutoPhoto>
    {
        public int CurrentPhoto { get; set; }
        public StoragePhoto(int _idcar)
        {
            using (var context = new CarsArchitecureEntities())
            {
                foreach (var i in context.PhotoDB.SqlQuery($"select * from PhotoDB where CarId={_idcar}"))
                {
                    this.Add(new AutoPhoto(i.Id, i.PhotoPath));
                }
            }
        }
    }
}
