using ASP_DotnetCoreMVC_CRUD.Data;
using ASP_DotnetCoreMVC_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DotnetCoreMVC_CRUD.Controllers
{
    public class UnitController : Controller
    {
        private readonly AppliDbContext _db;
        public UnitController(AppliDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // var list = _db.units.ToList();
            IEnumerable<Unit> list = _db.units;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Unit u)
        {
            if (ModelState.IsValid)
            {
                _db.units.Add(u);
                _db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(u);
        }

    }
}
