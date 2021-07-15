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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Project Project { get; set; }

        public ProjectsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpsertProj(int? id)
        {
            Project = new Project();
            if (id == null)
            {
                //create
                return View(Project);
            }
            //update
            Project = _db.Projects.FirstOrDefault(u => u.ProjectId == id);
            if (Project == null)
            {
                return NotFound();
            }
            return View(Project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertProj()
        {
            if (ModelState.IsValid)
            {
                if (Project.ProjectId == 0)
                {
                    //create
                    Project.Publisher = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("_currentUser"));
                    _db.Projects.Add(Project);
                } else
                {
                    _db.Projects.Update(Project);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Project);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Projects.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var projectFromDB = await _db.Projects.FirstOrDefaultAsync(u => u.ProjectId == id);
            if (projectFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Projects.Remove(projectFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
        #endregion
    }
}
