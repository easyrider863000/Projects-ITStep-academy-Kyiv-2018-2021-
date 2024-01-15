using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiveth_DataContext
{
    class Date
    {
        public ObservableCollection<string> Strings { get; set; }
        public string SelectedString { get; set; }
        public Student Student { get; set; }
        public Date()
        {
            Strings = new ObservableCollection<string>
            {
                "Hello","Bye","World","Burn"
            };
            Student = new Student
            {
                Name="John"
                ,LastName="Doe"
            };
        }
    }
}
