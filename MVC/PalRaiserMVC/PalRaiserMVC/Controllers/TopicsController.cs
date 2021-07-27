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
    public class TopicsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Topic Topic { get; set; }

        public TopicsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Topic> topics = _db.Topics.Include(t => t.Creator).ToList();

            return View(topics);
        }

        public IActionResult UpsertTopic(int? id)
        {
            Topic = new Topic();
            if (id == null)
            {
                //create
                return View(Topic);
            }
            //update
            Topic = _db.Topics.FirstOrDefault(t => t.TopicId == id);
            if (Topic == null)
            {
                return NotFound();
            }
            return View(Topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertTopic()
        {
            if (ModelState.IsValid)
            {
                Topic.Project = _db.Projects.FirstOrDefault(t => t.ProjectId == HttpContext.Session.GetInt32("currentProj"));
                Topic.Creator = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                Topic.Date = DateTimeOffset.Now;
                if (Topic.TopicId == 0)
                {
                    _db.Topics.Add(Topic);
                }
                else
                {
                    _db.Topics.Update(Topic);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Topic);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var topicFromDB = await _db.Topics.FirstOrDefaultAsync(t => t.TopicId == id);
            if (topicFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Topics.Remove(topicFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
    }
}
