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
    public class AppUsersController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public AppUser AppUser { get; set; }

        public AppUsersController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewProfile(int? id)
        {
            AppUser = _db.AppUsers.FirstOrDefault(u => u.UserId == id);
            if (AppUser == null)
            {
                return NotFound();
            }
            //Session["username"] = ;
            return View(AppUser);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.AppUsers.ToListAsync() });
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProjects(int id)
        {
            AppUser = _db.AppUsers.FirstOrDefault(u => u.UserId == id);
            if (AppUser == null)
            {
                return NotFound();
            }
            return Json(new { data = await _db.Projects.Where(v => v.Publisher == AppUser).ToListAsync() });
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
