using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Lesson_1.ADONETIntro.Repositories;

namespace IntroToADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ShopAdoConnectionString"].ConnectionString;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    string query = "select * from Product where Price>5000";
            //    SqlCommand cmd = new SqlCommand(query, connection);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"{reader["ProductName"]}  {reader["Price"]}");
            //    }
            //}

            string connectionString = ConfigurationManager.ConnectionStrings["ShopAdoConnectionString"].ConnectionString;
            GoodRepository repo = new GoodRepository(connectionString);

            var goood = repo.Get(2);
            Console.WriteLine(goood.GoodName);
            Console.WriteLine(goood.Id);
            Console.WriteLine(goood.CategoryId);
        }
    }
}
