using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Exam.Models
{
    public static class StaticCar
    {
        public static int GetLastCarId()
        {
            using (var context = new CarsArchitecureEntities())
            {
                //MessageBox.Show(context.PhotoDB.SqlQuery("SELECT TOP 1 Id FROM CarDB ORDER BY Id DESC").GetType().Name);
                var tmp = context.CarDB.SqlQuery("SELECT TOP 1 * FROM CarDB ORDER BY Id DESC").FirstOrDefault();
                return tmp.Id;
            }
        }
        public static bool Exist(int _idcar)
        {
            using (var context = new CarsArchitecureEntities())
            {
                var tmp = context.CarDB.SqlQuery($"select * from CarDB where Id={_idcar}").FirstOrDefault();
                if (tmp == null)
                    return false;
                else
                    return true;
            }
        }
        public static int GetManufacturerIdByName(string _name)
        {
            var t = new StorageCountryManufacturers();
            foreach(var i in t)
            {
                if(i.CountryName==_name)
                {
                    return i.Id;
                }
            }
            return 0;
        }
        public static int GetBodyTypeIdByName(string _name)
        {
            var t = new StorageBodyTypes();
            foreach (var i in t)
            {
                if (i.BodyTypeName == _name)
                {
                    return i.Id;
                }
            }
            return 0;
        }

        
    }
    
    public class Cars : ObservableCollection<AutoModel>
    {
        public Cars()
        {
            using (var context = new CarsArchitecureEntities())
            {
                foreach (var i in context.CarDB)
                {
                    var photo_ = context.PhotoDB.SqlQuery($"select * from PhotoDB where CarId={i.Id}");
                    List<AutoPhoto> list = new List<AutoPhoto>();
                    foreach(var en in photo_)
                    {
                        list.Add(new AutoPhoto(en.Id, en.PhotoPath));
                    }
                    this.Add(new AutoModel(i.Id,i.Name,i.Model,new CountryManufacturerModel(i.CountryManufacturerDB.Id,i.CountryManufacturerDB.ManufacturerName), new BodyTypeModel(i.BodyTypeDB.Id,i.BodyTypeDB.BodyName),i.Mass,i.EngineCapacity,i.Power,i.YearOfIssue,list));
                }
            }
        }
    }
}
