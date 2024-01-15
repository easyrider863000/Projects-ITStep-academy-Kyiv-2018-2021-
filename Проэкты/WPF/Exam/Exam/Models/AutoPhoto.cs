using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class StaticPhoto
    {
        public static int GetPhotoLastId()
        {
            using (var context = new CarsArchitecureEntities())
            {
                var tmp = context.PhotoDB.SqlQuery("SELECT TOP 1 * FROM PhotoDB ORDER BY Id DESC").FirstOrDefault();
                return tmp.Id;
            }
        }
    }
    [Serializable]
    public class AutoPhoto:IEquatable<AutoPhoto>
    {
        public AutoPhoto(int _id, string _path)
        {
            Id = _id;
            Path = _path;
        }
        public string Path { get; set; }
        public int Id { get; set; }

        public bool Equals(AutoPhoto other)
        {
            return Id == other.Id && Path == other.Path;
        }
    }
}
