using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2.ICommand.Models
{
	class Student
	{
		public string Name { get; set; }
		public string Lastname { get; set; }
		public static ObservableCollection<Student> GetStudents()
		{
			return new ObservableCollection<Student>
			{
				new Student { Name = "Alex", Lastname = "Klar"},
				new Student { Name = "John", Lastname = "Doe"},
				new Student { Name = "Lens", Lastname = "Newman"}
			};
		}
	}
}
