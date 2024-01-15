using Lesson_2.ICommand.Infrastructure;
using Lesson_2.ICommand.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2.ICommand.ViewModels
{
	class MainViewModel
	{

		#region Properties

		public ObservableCollection<Student> Students { get; set; }
		public Student SelectedStudent { get; set; }

		#endregion

		#region Commands 

		public System.Windows.Input.ICommand AddCommand { get; set; }
		public System.Windows.Input.ICommand RemoveCommand { get; set; }

		#endregion
		public MainViewModel()
		{
			Students = Student.GetStudents();
			AddCommand = new RelayCommand(x =>
			{
				Students.Add(new Student { Name = "a", Lastname = "a" });
			}, x => Students.Count < 5);
			//RemoveCommand = new RelayCommand(x => Students.Remove(SelectedStudent), x => Students.Count > 0);
			RemoveCommand = new RelayCommand(x => Students.Remove((Student)x), x => Students.Count > 0);
		}

	}
}
