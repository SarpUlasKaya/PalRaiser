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
    public class ReportsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Report Report { get; set; }

        public ReportsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Report> reports = _db.Reports.Include(r => r.User).ToList();

            return View(reports);
        }

        public IActionResult UpsertReport(int? id)
        {
            Report = new Report();
            if (id == null)
            {
                //create
                return View(Report);
            }
            //update
            Report = _db.Reports.FirstOrDefault(r => r.ReportId == id && r.ProjectId == HttpContext.Session.GetInt32("currentProj"));
            if (Report == null)
            {
                return NotFound();
            }
            return View(Report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertReport()
        {
            if (ModelState.IsValid)
            {
                Report.Project = _db.Projects.FirstOrDefault(p => p.ProjectId == HttpContext.Session.GetInt32("currentProj"));
                Report.User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                Report.Date = DateTimeOffset.Now;
                if (Report.ReportId == 0)
                {
                    _db.Reports.Add(Report);
                    Report.Project.ReportCount++;
                }
                else
                {
                    _db.Reports.Update(Report);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Report);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var reportFromDB = await _db.Reports.FirstOrDefaultAsync(r => r.ReportId == id && r.ProjectId == HttpContext.Session.GetInt32("currentProj"));
            if (reportFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Reports.Remove(reportFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
    }
}
