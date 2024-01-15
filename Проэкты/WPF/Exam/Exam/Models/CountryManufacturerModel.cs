using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    [Serializable]
    public class CountryManufacturerModel:IEquatable<CountryManufacturerModel>
    {
        public CountryManufacturerModel(int _id)
        {
            Id = _id;
        }
        public CountryManufacturerModel(int _id, string name)
        {
            Id = _id;
            CountryName = name;
        }
        public int Id { get; set; }
        public string CountryName { get; set; }
        public bool Equals(CountryManufacturerModel obj)
        {
            return obj.Id ==this.Id && obj.CountryName==CountryName;
        }
    }
}
