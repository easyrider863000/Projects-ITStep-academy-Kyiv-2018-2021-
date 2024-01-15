using System.Collections.ObjectModel;

namespace Exam.Models
{
    [System.Serializable]
    public class StorageBodyTypes:ObservableCollection<BodyTypeModel>
    {
        public StorageBodyTypes()
        {
            using (var context = new CarsArchitecureEntities())
            {
                foreach(var i in context.BodyTypeDB)
                {
                    this.Add(new BodyTypeModel(i.Id, i.BodyName));
                }
            }
        }
    }
}
