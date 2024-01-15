using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    class FileManager
    {
        public List<Person> Persons { private set; get; }
        BinaryFormatter formatter = new BinaryFormatter();
        string fullpath = "people.dat";
        public FileManager()
        {
            if(File.Exists(fullpath))
            {
                GetData();
            }
            else
            {
                Persons = DataLayer.GetPerson();
            }
        }
        void GetData()
        {
            using (FileStream fs = new FileStream(fullpath, FileMode.OpenOrCreate))
            {
                Persons = (List<Person>)formatter.Deserialize(fs);
            }
        }
        public void SaveData()
        {
            using (FileStream fs = new FileStream(fullpath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Persons);
            }
        }
    }
}
