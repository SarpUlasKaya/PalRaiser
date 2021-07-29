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
            List<Project> projects = _db.Projects.Include(p => p.Publisher).ToList();
            Project = projects.FirstOrDefault(u => u.ProjectId == id);
            if (Project.PublisherId == HttpContext.Session.GetInt32("currentUser"))
            {
                HttpContext.Session.SetInt32("canEditProj", 1);
            } else
            {
                HttpContext.Session.SetInt32("canEditProj", 0);
            }
            if (Project == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("currentProj", Project.ProjectId);
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
                AppUser newPublisher = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                Project.Publisher = newPublisher;
                if (Project.ProjectId == 0)
                {
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
                return RedirectToAction("ViewProj", new { id = Project.ProjectId });
            }
            return View(Project);
        }

        //[HttpDelete]
        public IActionResult DeleteProj(int id)
        {
            var projectFromDB = _db.Projects.FirstOrDefault(u => u.ProjectId == id);
            if (projectFromDB == null)
            {
                //return Json(new { success = false, message = "Error while deleting." });
                return NotFound();
            }
            _db.Projects.Remove(projectFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
            //return Json(new { success = true, message = "Deletion successful" });
        }

        public IActionResult FundProj()
        {
            return View();
        }

        public IActionResult AddFunds(int amount)
        {
            Project = _db.Projects.FirstOrDefault(u => u.ProjectId == HttpContext.Session.GetInt32("currentProj"));
            if (Project == null)
            {
                return NotFound();
            }
            Project.AmountRaised += amount;
            //_db.Projects.Update(Project);
            _db.SaveChanges();
            return RedirectToAction("ViewProj", new { id = Project.ProjectId });
        }

        public IActionResult ToggleLikeProj(int id)
        {
            var projectRatingFromDB = _db.ProjectRatings.FirstOrDefault(p => p.ProjectId == id && p.UserId == HttpContext.Session.GetInt32("currentUser"));
            Project = _db.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (projectRatingFromDB == null)
            {
                projectRatingFromDB = new ProjectRating
                {
                    Project = Project,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = true
                };
                _db.ProjectRatings.Add(projectRatingFromDB);
                Project.LikeCount++;
            }
            else if (!projectRatingFromDB.IsLike)
            {
                projectRatingFromDB.IsLike = true;
                Project.DislikeCount--;
                Project.LikeCount++;
            }
            else if (projectRatingFromDB.IsLike)
            {
                Project.LikeCount--;
                _db.ProjectRatings.Remove(projectRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("ViewProj", new { id = id });
        }

        public IActionResult ToggleDislikeProj(int id)
        {
            var projectRatingFromDB = _db.ProjectRatings.FirstOrDefault(p => p.ProjectId == id && p.UserId == HttpContext.Session.GetInt32("currentUser"));
            Project = _db.Projects.FirstOrDefault(p => p.ProjectId == id);
            if (projectRatingFromDB == null)
            {
                projectRatingFromDB = new ProjectRating
                {
                    Project = Project,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = false
                };
                _db.ProjectRatings.Add(projectRatingFromDB);
                Project.DislikeCount++;
            }
            else if (projectRatingFromDB.IsLike)
            {
                projectRatingFromDB.IsLike = false;
                Project.DislikeCount++;
                Project.LikeCount--;
            }
            else if (!projectRatingFromDB.IsLike)
            {
                Project.DislikeCount--;
                _db.ProjectRatings.Remove(projectRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("ViewProj", new { id = id });
        }

        public IActionResult RemoveProjRating(int id)
        {
            var projectRatingFromDB = _db.ProjectRatings.FirstOrDefault(p => p.ProjectId == id && p.UserId == HttpContext.Session.GetInt32("currentUser"));
            if (projectRatingFromDB == null)
            {
                return NotFound();
            }
            _db.ProjectRatings.Remove(projectRatingFromDB);
            _db.SaveChanges();
            return RedirectToAction("ViewProj", new { id = id });
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _db.Projects.ToListAsync();
            return Json(new { data = projects });
        }
        #endregion
    }
}
