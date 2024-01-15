using System;
using System.Collections.Generic;

namespace Exam.Models
{
    [Serializable]
    public class AutoModel
    {
        public AutoModel() { }
        public AutoModel(int _id,string name, string model, CountryManufacturerModel countryManufacturer, BodyTypeModel bodyType, int mass, double engineCapacity, int power, int yearOfIssue, List<AutoPhoto> autophotos)
        {
            Id = _id;
            Name = name;
            Model = model;
            CountryManufacturer = countryManufacturer;
            BodyType = bodyType;
            Mass = mass;
            EngineCapacity = engineCapacity;
            Power = power;
            YearOfIssue = yearOfIssue;
            Photos = autophotos;
            if(Photos.Count>0)
            {
                CurrentPhoto = Photos[0];
            }
        }
        public int Id { get; set; }
        public List<AutoPhoto> Photos { get; set; }
        public AutoPhoto CurrentPhoto { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public CountryManufacturerModel CountryManufacturer { get; set; }
        public BodyTypeModel BodyType { get; set; }
        public int Mass { get; set; }
        public double EngineCapacity { get; set; }
        public int Power { get; set; }
        public int YearOfIssue { get; set; }
    }
}
