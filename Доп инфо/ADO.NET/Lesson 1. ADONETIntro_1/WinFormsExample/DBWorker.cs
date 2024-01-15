using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsExample
{
	class DBWorker
	{
		string connectionString;
		SqlConnection connection;
		SqlDataAdapter dataAdapter;
		DataTable table;
		public DBWorker()
		{
			connectionString = ConfigurationManager.ConnectionStrings["ShopAdoConnectionString"].ConnectionString;
		}
		public DataTable LoadData()
		{
			connection = new SqlConnection(connectionString);
			
				dataAdapter = new SqlDataAdapter("select * from Product", connection);
				SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
				dataAdapter.InsertCommand = builder.GetInsertCommand();
				dataAdapter.UpdateCommand = builder.GetUpdateCommand();
				dataAdapter.DeleteCommand = builder.GetDeleteCommand();
				table = new DataTable();
				dataAdapter.Fill(table);

			connection.Close();
			return table;
		}
		public void Save()
		{
			connection.Open();
				dataAdapter.Update(table);
			connection.Close();
		}
	}
}
