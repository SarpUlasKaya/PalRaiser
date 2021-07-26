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

        public IActionResult ViewProj(int? id)
        {
            Project = _db.Projects.FirstOrDefault(u => u.ProjectId == id);
            if (Project.PublisherId == HttpContext.Session.GetInt32("currentProj"))
            {
                HttpContext.Session.SetInt32("canEditProj", 1);
            } else
            {
                HttpContext.Session.SetInt32("canEditProj", 0);
            }
            HttpContext.Session.SetInt32("currentProj", Project.ProjectId);
            if (Project == null)
            {
                return NotFound();
            }
            return View(Project);
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
                    Project.Publisher = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                    _db.Projects.Add(Project);
                    var update = new Update
                    {
                        Title = Project.ProjName + " is now on PalRaiser!",
                        Description = "Support the creators of " +
                        Project.ProjName + " by funding them on PalRaiser! You have the power to help someone reach their dreams.",
                        Date = DateTimeOffset.Now,
                        Project = Project
                    };
                    _db.Updates.Add(update);
                } else
                {
                    _db.Projects.Update(Project);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Project);
        }

        public IActionResult FundProj(int id)
        {
            Project = _db.Projects.FirstOrDefault(u => u.ProjectId == id);
            if (Project == null)
            {
                return NotFound();
            }
            return View(Project);
        }

        public IActionResult AddFunds(int amount)
        {
            Project = _db.Projects.FirstOrDefault(u => u.ProjectId == HttpContext.Session.GetInt32("currentProj"));
            if (Project == null)
            {
                return NotFound();
            }
            //Fund Project
            Project.AmountRaised += amount;
            _db.Projects.Update(Project);
            _db.SaveChanges();
            return RedirectToAction("FundsTransferred", new { id = HttpContext.Session.GetInt32("currentProj") });
        }

        public IActionResult FundsTransferred(int id)
        {
            Project = _db.Projects.FirstOrDefault(u => u.ProjectId == id);
            if (Project == null)
            {
                return NotFound();
            }
            return View(Project);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _db.Projects.ToListAsync();
            return Json(new { data = projects });
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
