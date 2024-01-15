using DAL_Paggination;
using DAL_Paggination.Models;
using DAL_Paggination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
            ViewBag.Goods = goodRepository
                            .GetAll()
                             .Skip((id - 1) * 6)
                              .Take(6)
                               .ToList();
            return View();
        }
        public ActionResult Categories(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
            ViewBag.Categories = categoryRepository
                            .GetAll()
                             .Skip((id - 1) * 6)
                              .Take(6)
                               .ToList();
            return View("Categories");
        }
        public ActionResult Manufacturers(int id = 1)
        {
            ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
            ViewBag.Manufacturers = manufacturerRepository
                            .GetAll()
                             .Skip((id - 1) * 6)
                              .Take(6)
                               .ToList();
            return View("Manufacturers");
        }
        public ActionResult Delete(int id, string type)
        {
            if (type == "Good")
            {
                goodRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else if (type == "Category")
            {
                if(!GoodRepoMethods.IsInvolvedCategory(goodRepository, id))
                    categoryRepository.Delete(id);
                return RedirectToAction("Categories");
            }
            else if (type == "Manufacturer")
            {
                if (!GoodRepoMethods.IsInvolvedManufacturer(goodRepository, id))
                    manufacturerRepository.Delete(id);
                return RedirectToAction("Manufacturers");
            }
            return RedirectToAction("Index");
        }
    }
}