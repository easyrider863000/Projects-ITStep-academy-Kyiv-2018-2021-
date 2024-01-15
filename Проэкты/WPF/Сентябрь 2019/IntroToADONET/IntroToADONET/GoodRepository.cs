using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1.ADONETIntro.Repositories
{
	class GoodRepository : IRepository<Good>
	{
		string connString;
		
		public GoodRepository(string conn)
		{
			connString = conn;
		}
		public void Create(Good obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Good Get(int id)
		{
			Good good = new Good();
			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();
				SqlCommand cmd = new SqlCommand($"select * from Product where ProductId = {id}", connection);
				SqlDataReader dr = cmd.ExecuteReader();
				if (dr.HasRows)
				{
					dr.Read();
					good.Id = id;
					good.GoodName = dr["ProductName"].ToString();
					good.Price = (decimal)dr["Price"];
					good.GoodCount = (decimal)dr["ProductCount"];
					good.ManufacturerId = (int)dr["ManufacturerId"];
					good.CategoryId = (int)dr["CategoryId"];
				}
			}

			return good;
		}

		public IEnumerable<Good> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(int id, Good obj)
		{
			using (SqlConnection connection = new SqlConnection(connString))
			{
				connection.Open();
				string query = $@"update Good
								  set ProductName = '{obj.GoodName}'
							      where ProductId = {id}";
				SqlCommand cmd = new SqlCommand(query, connection);
				cmd.ExecuteNonQuery();
			}
		}
	}
}
