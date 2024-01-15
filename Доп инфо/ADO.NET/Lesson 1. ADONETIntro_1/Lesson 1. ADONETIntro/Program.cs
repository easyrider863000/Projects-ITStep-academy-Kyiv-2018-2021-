using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Lesson_1.ADONETIntro.Repositories;

namespace Lesson_1.ADONETIntro
{
	class Program
	{
		static void Main(string[] args)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["ShopAdoConnectionString"].ConnectionString;
			GoodRepository repo = new GoodRepository(connectionString);

			var good = repo.Get(22);
			Console.WriteLine(good.GoodName);
			Console.WriteLine(good.Id);
			Console.WriteLine(good.Price);
			good.GoodName = "Bye";
			good.Price = 55;
			good.CategoryId = 2;
			repo.Update(22, good);
		}
	}
}
