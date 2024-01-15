using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class BodyTypeModel:IEquatable<BodyTypeModel>
    {
        public BodyTypeModel(int _id)
        {
            Id = _id;
        }
        public BodyTypeModel(int _id,string name)
        {
            Id = _id;
            BodyTypeName = name;
        }
        public int Id { get; set; }
        public string BodyTypeName { get; set; } 
        public bool Equals(BodyTypeModel other)
        {
            return other.Id == this.Id && other.BodyTypeName==BodyTypeName;
        }
    }
}
