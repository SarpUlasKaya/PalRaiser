using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalRaiserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserMVC.Controllers
{
    public class UpdatesController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Update Update { get; set; }

        public UpdatesController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Update> updates = _db.Updates.Include(u => u.Project).ToList();

            return View(updates);
        }

        public IActionResult UpsertUpdate(int? id)
        {
            Update = new Update();
            if (id == null)
            {
                //create
                return View(Update);
            }
            //update
            Update = _db.Updates.FirstOrDefault(u => u.UpdateId == id);
            if (Update == null)
            {
                return NotFound();
            }
            return View(Update);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertUpdate()
        {
            if (ModelState.IsValid)
            {
                Update.Project = _db.Projects.FirstOrDefault(p => p.ProjectId == HttpContext.Session.GetInt32("currentProj"));
                Update.Date = DateTimeOffset.Now;
                if (Update.UpdateId == 0)
                {
                    _db.Updates.Add(Update);
                }
                else
                {
                    _db.Updates.Update(Update);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Update);
        }

        public IActionResult DeleteUpdate(int id)
        {
            var updateFromDB = _db.Updates.FirstOrDefault(u => u.UpdateId == id);
            if (updateFromDB == null)
            {
                return NotFound();
            }
            _db.Updates.Remove(updateFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
