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

        public IActionResult DeleteTopic(int id)
        {
            var topicFromDB = _db.Topics.FirstOrDefault(t => t.TopicId == id);
            if (topicFromDB == null)
            {
                return NotFound();
            }
            _db.Topics.Remove(topicFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ToggleLikeTopic(int id)
        {
            var topicRatingFromDB = _db.TopicRatings.FirstOrDefault(t => t.TopicId == id && t.UserId == HttpContext.Session.GetInt32("currentUser"));
            Topic = _db.Topics.FirstOrDefault(t => t.TopicId == id);
            if (topicRatingFromDB == null)
            {
                topicRatingFromDB = new TopicRating
                {
                    Topic = Topic,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = true
                };
                _db.TopicRatings.Add(topicRatingFromDB);
                Topic.LikeCount++;
            }
            else if (!topicRatingFromDB.IsLike)
            {
                topicRatingFromDB.IsLike = true;
                Topic.DislikeCount--;
                Topic.LikeCount++;
            }
            else if (topicRatingFromDB.IsLike)
            {
                Topic.LikeCount--;
                _db.TopicRatings.Remove(topicRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ToggleDislikeTopic(int id)
        {
            var topicRatingFromDB = _db.TopicRatings.FirstOrDefault(t => t.TopicId == id && t.UserId == HttpContext.Session.GetInt32("currentUser"));
            Topic = _db.Topics.FirstOrDefault(t => t.TopicId == id);
            if (topicRatingFromDB == null)
            {
                topicRatingFromDB = new TopicRating
                {
                    Topic = Topic,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = false
                };
                _db.TopicRatings.Add(topicRatingFromDB);
                Topic.DislikeCount++;
            }
            else if (topicRatingFromDB.IsLike)
            {
                topicRatingFromDB.IsLike = false;
                Topic.DislikeCount++;
                Topic.LikeCount--;
            }
            else if (!topicRatingFromDB.IsLike)
            {
                Topic.DislikeCount--;
                _db.TopicRatings.Remove(topicRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveTopicRating(int id)
        {
            var topicRatingFromDB = _db.TopicRatings.FirstOrDefault(t => t.TopicId == id && t.UserId == HttpContext.Session.GetInt32("currentUser"));
            if (topicRatingFromDB == null)
            {
                return NotFound();
            }
            _db.TopicRatings.Remove(topicRatingFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
