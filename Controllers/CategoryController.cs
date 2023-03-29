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
        public IActionResult Index()
        {
            
            IEnumerable<Category> objCategoryList = _db.Category.ToList();
 
            return View(objCategoryList);
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
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}