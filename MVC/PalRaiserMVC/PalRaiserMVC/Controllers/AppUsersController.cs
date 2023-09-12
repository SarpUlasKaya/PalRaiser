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

        public IActionResult ViewProfile(int id)
        {
            AppUser = _db.AppUsers.FirstOrDefault(u => u.UserId == id);
            if (AppUser == null)
            {
                return NotFound();
            }
            if (AppUser.UserId == HttpContext.Session.GetInt32("currentUser"))
            {
                HttpContext.Session.SetInt32("canEditProfile", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("canEditProfile", 0);
            }
            HttpContext.Session.SetInt32("profileUser", AppUser.UserId);
            return View(AppUser);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.AppUsers.ToListAsync() });
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProjects()
        {
            AppUser = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("profileUser"));
            if (AppUser == null)
            {
                return NotFound();
            }
            return Json(new { data = await _db.Projects.Where(p => p.Publisher == AppUser).ToListAsync() });
        }
        #endregion
    }
}
