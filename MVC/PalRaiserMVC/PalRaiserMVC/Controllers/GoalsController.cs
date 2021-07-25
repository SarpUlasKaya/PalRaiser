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
    public class GoalsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Goal Goal { get; set; }

        public GoalsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Goal> goals = _db.Goals.ToList();

            return View(goals);
        }

        public IActionResult UpsertGoal(int? id)
        {
            Goal = new Goal();
            if (id == null)
            {
                //create
                return View(Goal);
            }
            //update
            Goal = _db.Goals.FirstOrDefault(g => g.GoalId == id && g.ProjectId == HttpContext.Session.GetInt32("currentProj"));
            if (Goal == null)
            {
                return NotFound();
            }
            return View(Goal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertGoal()
        {
            if (ModelState.IsValid)
            {
                if (Goal.ProjectId == 0)
                {
                    //create
                    Goal.Project = _db.Projects.FirstOrDefault(p => p.ProjectId == HttpContext.Session.GetInt32("currentProj"));
                    _db.Goals.Add(Goal);
                }
                else
                {
                    _db.Goals.Update(Goal);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Goal);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var goalFromDB = await _db.Goals.FirstOrDefaultAsync(g => g.GoalId == id && g.ProjectId == HttpContext.Session.GetInt32("currentProj"));
            if (goalFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Goals.Remove(goalFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
    }
}
