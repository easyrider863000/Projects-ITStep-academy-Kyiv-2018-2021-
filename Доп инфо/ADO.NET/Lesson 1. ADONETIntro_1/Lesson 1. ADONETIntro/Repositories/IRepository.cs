using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1.ADONETIntro.Repositories
{
	interface IRepository<T>
	{
		T Get(int id);
		IEnumerable<T> GetAll();
		void Create(T obj);
		void Update(int id, T obj);
		void Delete(int id);
	}
}
