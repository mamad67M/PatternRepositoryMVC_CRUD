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
                TempData["success"] = "Unit créé avec succès";
                return RedirectToAction("Index");
            } 
            return View(u);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           // var EditedObj = _db.units.Find(id);
             var EditedObj = _db.units.SingleOrDefault(a => a.Id == id);
            if (EditedObj == null)
            {
                return NotFound();
            }
            return View(EditedObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Unit u)
        {
            if (ModelState.IsValid)
            {
                _db.units.Update(u);
                _db.SaveChanges();
                TempData["success"] = "Unit modifié avec succès";

                return RedirectToAction("Index");
            }
            return View(u);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var EditedObj = _db.units.Find(id);
            var EditedObj = _db.units.SingleOrDefault(a => a.Id == id);
            if (EditedObj == null)
            {
                return NotFound();
            }
            return View(EditedObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int ? id)
        {
            var u = _db.units.SingleOrDefault(b => b.Id == id);
            if (ModelState.IsValid)
            {
                _db.units.Remove(u);
                _db.SaveChanges();
                TempData["success"] = "Unit supprimé avec succès";

                return RedirectToAction("Index");
            }
            return View(u);
        }

        public IActionResult Details(int id)
        {
            var u = GetUnit(id);
            return View(u);
        }
        public Unit GetUnit(int id)
        {
            Unit unit = _db.units.Find(id);
            return unit;
        }
    }
}
