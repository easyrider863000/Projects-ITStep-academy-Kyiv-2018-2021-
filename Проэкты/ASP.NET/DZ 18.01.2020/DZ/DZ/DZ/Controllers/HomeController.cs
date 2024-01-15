using DZ.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DZ.Controllers
{
    public class HomeController : Controller
    {
        DataSet ds;
        List<Good> Goods = new List<Good>();
        List<Category> Categories = new List<Category>();
        List<Manufacturer> Manufacturers = new List<Manufacturer>();
        public HomeController() : base()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ShopAdoConnectionString"].ConnectionString;
            string sql = "SELECT * FROM dbo.Category SELECT * FROM dbo.Manufacturer SELECT * FROM dbo.Good ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Создаем объект DataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
            }
            Categories.AddRange(from category in ds.Tables[0].AsEnumerable()
                                select new Category
                                {
                                    CategoryId = Int32.Parse(category["CategoryId"].ToString()),
                                    CategoryName = category["CategoryName"].ToString()
                                });
            Manufacturers.AddRange(from manufacturer in ds.Tables[1].AsEnumerable()
                                   select new Manufacturer
                                   {
                                       ManufacturerId = Int32.Parse(manufacturer["ManufacturerId"].ToString()),
                                       ManufacturerName = manufacturer["ManufacturerName"].ToString()
                                   });
            Goods.AddRange(from good in ds.Tables[2].AsEnumerable()
                           select new Good
                           {
                               GoodId = Int32.Parse(good["GoodId"].ToString()),
                               GoodName = good["GoodName"].ToString(),
                               GoodCount = (decimal)good["GoodCount"],
                               Price = (decimal)good["Price"],
                               CategoryId = good["CategoryId"] as int?,
                               ManufacturerId = good["ManufacturerId"] as int?
                           });
        }
        // GET: Home
        public ViewResult Index()
        {
            ViewBag.DataSource = Goods;
            return View("View");
        }
        public ViewResult Category()
        {
            ViewBag.DataSource = Categories;
            return View("Categories");
        }
        public ViewResult Manufacturer()
        {
            ViewBag.DataSource = Manufacturers;
            return View("Manufacturers");
        }
    }
}