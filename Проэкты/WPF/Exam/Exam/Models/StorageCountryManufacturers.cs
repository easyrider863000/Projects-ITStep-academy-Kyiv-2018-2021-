using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Exam.Models
{
    [System.Serializable]
    public class StorageCountryManufacturers:ObservableCollection<CountryManufacturerModel>
    {
        public StorageCountryManufacturers()
        {
            using (var context = new CarsArchitecureEntities())
            {
                foreach (var i in context.CountryManufacturerDB)
                {
                    this.Add(new CountryManufacturerModel(i.Id, i.ManufacturerName));
                }
            }
        }
    }
}
