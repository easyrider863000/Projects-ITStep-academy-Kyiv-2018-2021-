using DAL_Paggination;
using DAL_Paggination.Models;
using DAL_Paggination.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DZ.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Good> goodRepository;
        IRepository<Category> categoryRepository;
        IRepository<Manufacturer> manufacturerRepository;
        public HomeController(IRepository<Good> good,
        IRepository<Category> category,
        IRepository<Manufacturer> manufacturer)
        {
            goodRepository = good;
            categoryRepository = category;
            manufacturerRepository = manufacturer;
            ViewBag.good = goodRepository;
        }
        public ActionResult Index()
        {
            ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
            return View(GetList(goodRepository,1));
        }
        
        #region Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateGood([Bind(Include = "GoodId,GoodName,ManufacturerId,CategoryId,Price,GoodCount")] Good good)
        {
            if (ModelState.IsValid)
            {
                goodRepository.Create(good);
                ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
                return PartialView("TableGoods", GetList(goodRepository, 1));
            }

            ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName");
            ViewBag.ManufacturerId = new SelectList(manufacturerRepository.GetAll(), "ManufacturerId", "ManufacturerName");
            return PartialView("CreateGood", good);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateCategory([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Create(category);
                ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
                return PartialView("TableCategories", GetList(categoryRepository, 1));
            }
            return PartialView("CreateCategory", category);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateManufacturer([Bind(Include = "ManufacturerId,ManufacturerName")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerRepository.Create(manufacturer);
                ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
                return PartialView("TableManufacturers", GetList(manufacturerRepository, 1));
            }
            return PartialView("CreateManufacturer", manufacturer);
        }

#endregion
        #region Update
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public PartialViewResult EditCategory([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(category);
                ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
                return PartialView("TableCategories", GetList(categoryRepository, 1));
            }
            return PartialView(category);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public PartialViewResult EditManufacturer([Bind(Include = "ManufacturerId,ManufacturerName")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                manufacturerRepository.Update(manufacturer);
                ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
                return PartialView("TableManufacturers", GetList(manufacturerRepository, 1));
            }
            return PartialView(manufacturer);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public PartialViewResult EditGood([Bind(Include = "GoodId,GoodName,ManufacturerId,CategoryId,Price,GoodCount")] Good good)
        {
            if (ModelState.IsValid)
            {
                goodRepository.Update(good);
                ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
                return PartialView("TableGoods",GetList(goodRepository,1));
            }
            ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName", good.Category);
            ViewBag.ManufacturerId = new SelectList(manufacturerRepository.GetAll(), "ManufacturerId", "ManufacturerName", good.Manufacturer);
            return PartialView(good);
        }
        #endregion
        #region CreateButton
        [Authorize]
        public PartialViewResult Create(string type)
        {
            if (type == "Good")
            {
                ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName");
                ViewBag.ManufacturerId = new SelectList(manufacturerRepository.GetAll(), "ManufacturerId", "ManufacturerName");
                return PartialView("CreateGood", new Good());
            }
            else if (type == "Category")
            {
                return PartialView("CreateCategory", new Category());
            }
            else if (type == "Manufacturer")
            {
                return PartialView("CreateManufacturer", new Manufacturer());
            }
            return null;
        }
        #endregion
        #region UpdateButton
        [Authorize]
        public PartialViewResult Update(int id, string type)
        {
            if (type == "Good")
            {
                ViewBag.CategoryId = new SelectList(categoryRepository.GetAll(), "CategoryId", "CategoryName", goodRepository.Get(id).Category);
                ViewBag.ManufacturerId = new SelectList(manufacturerRepository.GetAll(), "ManufacturerId", "ManufacturerName", goodRepository.Get(id).Manufacturer);
                return PartialView("EditGood", goodRepository.Get(id));
            }
            else if (type == "Category")
            {
                return PartialView("EditCategory", categoryRepository.Get(id));
            }
            else if (type == "Manufacturer")
            {
                return PartialView("EditManufacturer", manufacturerRepository.Get(id));
            }
            return null;
        }
        #endregion
        #region CancelButton
        public PartialViewResult Cancel(int id, string type)
        {
            if (type == "Good")
            {
                ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
                return PartialView("TableGoods", GetList(goodRepository,1));
            }
            else if (type == "Category")
            {
                ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
                return PartialView("TableCategories", GetList(categoryRepository,1));
            }
            else if (type == "Manufacturer")
            {
                ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
                return PartialView("TableManufacturers", GetList(manufacturerRepository,1));
            }
            return null;
        }
        #endregion
        #region DeleteButton
        [Authorize]
        public PartialViewResult Delete(int id, string type)
        {
            if (type == "Good")
            {
                goodRepository.Delete(id);
                ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
                return PartialView("TableGoods", GetList(goodRepository,1));
            }
            else if (type == "Category")
            {
                categoryRepository.Delete(id);
                ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
                return PartialView("TableCategories", GetList(categoryRepository,1));
            }
            else if (type == "Manufacturer")
            {
                manufacturerRepository.Delete(id);
                ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
                return PartialView("TableManufacturers", GetList(manufacturerRepository,1));
            }
            return null;
        }
        #endregion
        #region GetPartialTables
        public PartialViewResult TableManufacturers(int id = 1)
        {
            ViewBag.NameTable = "TableManufacturers";
            ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
            return PartialView(GetList(manufacturerRepository,id));
        }
        public PartialViewResult TableCategories(int id = 1)
        {
            ViewBag.NameTable = "TableCategories";
            ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
            return PartialView(GetList(categoryRepository,id));
        }
        public PartialViewResult TableGoods(int id = 1)
        {
            ViewBag.NameTable = "TableGoods";
            ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
            return PartialView(GetList(goodRepository, id));
        }
        #endregion
        #region helpFunctions
        public List<Category> GetList(IRepository<Category> repo, int id)
        {
            return repo.GetAll()
                        .Skip((id - 1) * 6)
                         .Take(6)
                          .ToList();
        }
        public List<Good> GetList(IRepository<Good> repo, int id)
        {
            return repo.GetAll()
                        .Skip((id - 1) * 6)
                         .Take(6)
                          .ToList();
        }
        public List<Manufacturer> GetList(IRepository<Manufacturer> repo, int id)
        {
            return repo.GetAll()
                        .Skip((id - 1) * 6)
                         .Take(6)
                          .ToList();
        }
        #endregion
    }
}