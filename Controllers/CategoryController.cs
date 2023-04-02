using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.Data;
using BulkyBook.Models;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db) {
            _db = db;
        }

        //GET
        //public IActionResult Index()
        //{
            
        //    IEnumerable<Category> objCategoryList = _db.Category.ToList();
 
        //    return View(objCategoryList);
        //}

        //GET
        public IActionResult Index(string SearchString)
        {
            //Console.WriteLine("SearchString : " + SearchString);
            var objCategory = from b in _db.Category select b;
            ViewData["CurrentFilter"] = SearchString;
            if (!String.IsNullOrEmpty(SearchString))
            {
                //Console.WriteLine("inside if");
                objCategory = objCategory.Where(s => s.Name.Contains(SearchString));
                //Console.WriteLine(objCategory.ToList());
            }

            //switch (sortOrder)
            //{
            //    case "Name_Desc":
            //        objCategory = objCategory.OrderByDescending(s => s.Name);
            //        break;
            //    case "DisplayOrder_Acen":
            //        objCategory = objCategory.OrderByDescending(s => s.Name);
            //        break;
            //    case "DisplayOrder_Desc":
            //        objCategory = objCategory.OrderByDescending(s => s.DisplayOrder);
            //        break;
            //    default:
            //        objCategory = objCategory.OrderBy(s => s.Name);
            //        break;

            //}

            return View(objCategory.ToList());
        }


        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder cannot be exactly same");
            }
            if (ModelState.IsValid)
            {   
                _db.Category.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created !";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CategoryObj = _db.Category.Find(id);
            //var CategoryObjFromDbFirst = _db.Category.FirstOrDefault(u => u.Id == id);
            //var CategoryObjFromDbSingle = _db.Category.SingleOrDefault(u => u.Id == id);
            if (CategoryObj == null)
            {
                return NotFound();
            }

            return View(CategoryObj);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and DisplayOrder cannot be exactly same");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated !";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CategoryObj = _db.Category.Find(id);
            //var CategoryObjFromDbFirst = _db.Category.FirstOrDefault(u => u.Id == id);
            //var CategoryObjFromDbSingle = _db.Category.SingleOrDefault(u => u.Id == id);
            if (CategoryObj == null)
            {
                return NotFound();
            }

            return View(CategoryObj);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            
            
            _db.Category.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted !";

            return RedirectToAction("Index");
           
        }
    }
}