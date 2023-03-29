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

        public IActionResult Index()
        {
            
            IEnumerable<Category> objCategoryList = _db.Category.ToList();
            
            return View(objCategoryList);
        }
    }
}