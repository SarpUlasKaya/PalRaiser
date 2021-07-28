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
    public class FollowRequestsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public FollowRequest FollowRequest { get; set; }

        public FollowRequestsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewReceivedRequests()
        {
            List<FollowRequest> requests = _db.FollowRequests.Include(f => f.Sender).Where(f => !f.IsAccepted).ToList();

            return View(requests);
        }

        public IActionResult ViewSentRequests()
        {
            List<FollowRequest> requests = _db.FollowRequests.Include(f => f.Receiver).Where(f => !f.IsAccepted).ToList();

            return View(requests);
        }
        public IActionResult ViewFollowers()
        {
            return View();
        }

        public IActionResult ViewFollowedUsers()
        {
            return View();
        }

        public IActionResult SendRequest(int id)
        {
            FollowRequest = new FollowRequest
            {
                Sender = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                Receiver = _db.AppUsers.FirstOrDefault(u => u.UserId == id),
                IsAccepted = false
            };
            _db.FollowRequests.Add(FollowRequest);
            _db.SaveChanges();
            return RedirectToAction("ViewProfile", "AppUsers", new { id = id });
        }

        public IActionResult AcceptRequest(int id)
        {
            FollowRequest = _db.FollowRequests.FirstOrDefault(f => f.RequestId == id && !f.IsAccepted);
            if (FollowRequest == null)
            {
                return NotFound();
            }
            FollowRequest.IsAccepted = true;
            //_db.Projects.Update(Project);
            _db.SaveChanges();
            return RedirectToAction("ViewReceivedRequests");
        }

        public IActionResult DenyOrRemoveFollower(int id)
        {
            var followRequestFromDB = _db.FollowRequests.FirstOrDefault(f => f.SenderId == id);
            bool redirect = followRequestFromDB.IsAccepted;
            if (FollowRequest == null)
            {
                return NotFound();
            }
            _db.FollowRequests.Remove(followRequestFromDB);
            _db.SaveChanges();
            if (redirect)
                return RedirectToAction("ViewFollowers");
            else
                return RedirectToAction("ViewReceivedRequests");
        }

        public IActionResult Unfollow(int id)
        {
            var followRequestFromDB = _db.FollowRequests.FirstOrDefault(r => r.ReceiverId == id);
            bool redirect = followRequestFromDB.IsAccepted;
            if (followRequestFromDB == null)
            {
                return NotFound();
            }
            _db.FollowRequests.Remove(followRequestFromDB);
            _db.SaveChanges();
            if (redirect)
                return RedirectToAction("ViewFollowedUsers");
            else
                return RedirectToAction("ViewSentRequests");
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetFollowers()
        {
            return Json(new { data = await _db.FollowRequests.Where(f => f.ReceiverId == HttpContext.Session.GetInt32("profileUser") && f.IsAccepted).Include(f => f.Sender).ToListAsync() });
        }

        [HttpGet]
        public async Task<IActionResult> GetFollowedUsers()
        {
            return Json(new { data = await _db.FollowRequests.Where(f => f.SenderId == HttpContext.Session.GetInt32("profileUser") && f.IsAccepted).Include(f => f.Receiver).ToListAsync() });
        }
        #endregion
    }
}
