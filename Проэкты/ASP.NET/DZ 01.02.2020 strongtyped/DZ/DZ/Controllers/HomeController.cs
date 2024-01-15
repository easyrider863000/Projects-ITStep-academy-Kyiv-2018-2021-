using DAL_Paggination;
using DAL_Paggination.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DZ.Controllers
{
    public class HomeController : Controller
    {
        GoodRepository goodRepository;
        CategoryRepository categoryRepository;
        ManufacturerRepository manufacturerRepository;
        public HomeController()
        {
            goodRepository = new GoodRepository();
            categoryRepository = new CategoryRepository();
            manufacturerRepository = new ManufacturerRepository();
            ViewBag.good = goodRepository;
        }
        public ActionResult Index()
        {
            ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
            var goods = goodRepository
                        .GetAll()
                         .Skip((1 - 1) * 6)
                          .Take(6)
                           .ToList();
            return View(goods);
        }
        public PartialViewResult Delete(int id, string type)
        {
            if (type == "Good")
            {
                goodRepository.Delete(id);
                ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
                var goods = goodRepository
                            .GetAll()
                             .Skip((1 - 1) * 6)
                              .Take(6)
                               .ToList();
                return PartialView("TableGoods", goods);
            }
            else if (type == "Category")
            {
                if(!goodRepository.IsInvolvedCategory(id))
                    categoryRepository.Delete(id);
                ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
                var categories = categoryRepository
                            .GetAll()
                             .Skip((1 - 1) * 6)
                              .Take(6)
                               .ToList();
                return PartialView("TableCategories", categories);
            }
            else if (type == "Manufacturer")
            {
                if (!goodRepository.IsInvolvedManufacturer(id))
                    manufacturerRepository.Delete(id);
                ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
                var manufacturers = manufacturerRepository
                            .GetAll()
                             .Skip((1 - 1) * 6)
                              .Take(6)
                               .ToList();
                return PartialView("TableManufacturers", manufacturers);
            }
            return null;
        }

        
        public PartialViewResult TableManufacturers(int id = 1)
        {
            ViewBag.NameTable = "TableManufacturers";
            ViewBag.PageCount = (int)Math.Ceiling(manufacturerRepository.GetAll().Count() / 6.0);
            var manufacturers = manufacturerRepository
                            .GetAll()
                             .Skip((id - 1) * 6)
                              .Take(6)
                               .ToList();
            return PartialView(manufacturers);
        }
        public PartialViewResult TableCategories(int id = 1)
        {
            ViewBag.NameTable = "TableCategories";
            ViewBag.PageCount = (int)Math.Ceiling(categoryRepository.GetAll().Count() / 6.0);
            var categories = categoryRepository
                            .GetAll()
                             .Skip((id - 1) * 6)
                              .Take(6)
                               .ToList();
            return PartialView(categories);
        }
        public PartialViewResult TableGoods(int id = 1)
        {
            ViewBag.NameTable = "TableGoods";
            ViewBag.PageCount = (int)Math.Ceiling(goodRepository.GetAll().Count() / 6.0);
            var goods = goodRepository
                            .GetAll()
                             .Skip((id - 1) * 6)
                              .Take(6)
                               .ToList();
            return PartialView(goods);
        }
    }
}