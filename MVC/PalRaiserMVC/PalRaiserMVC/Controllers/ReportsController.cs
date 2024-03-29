﻿using Microsoft.AspNetCore.Http;
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
            Report = _db.Reports.FirstOrDefault(r => r.ReportId == id);
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

        public IActionResult DeleteReport(int id)
        {
            var reports = _db.Reports.Include(r => r.Project).ToList();
            var reportFromDB = reports.FirstOrDefault(r => r.ReportId == id);
            if (reportFromDB == null)
            {
                return NotFound();
            }
            reportFromDB.Project.ReportCount--;
            _db.Reports.Remove(reportFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
