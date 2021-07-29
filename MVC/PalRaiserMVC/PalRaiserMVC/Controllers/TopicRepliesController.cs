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
    public class TopicRepliesController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public TopicReply TopicReply { get; set; }

        public TopicRepliesController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            HttpContext.Session.SetInt32("currentTopic", id);
            List<TopicReply> topicReplies = _db.TopicReplies.Include(t => t.User).ToList();

            return View(topicReplies);
        }

        public IActionResult UpsertTopicReply(int? id)
        {
            TopicReply = new TopicReply();
            if (id == null)
            {
                //create
                return View(TopicReply);
            }
            //update
            TopicReply = _db.TopicReplies.FirstOrDefault(t => t.TopicReplyId == id);
            if (TopicReply == null)
            {
                return NotFound();
            }
            return View(TopicReply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertTopicReply()
        {
            if (ModelState.IsValid)
            {
                TopicReply.Topic = _db.Topics.FirstOrDefault(t => t.TopicId == HttpContext.Session.GetInt32("currentTopic"));
                TopicReply.User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                TopicReply.Date = DateTimeOffset.Now;
                if (TopicReply.TopicReplyId == 0)
                {
                    _db.TopicReplies.Add(TopicReply);
                    TopicReply.Topic.NoOfReplies++;
                }
                else
                {
                    _db.TopicReplies.Update(TopicReply);
                }
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentTopic") });
            }
            return View(TopicReply);
        }

        public IActionResult DeleteTopicReply(int id)
        {
            var topicReplies = _db.TopicReplies.Include(t => t.Topic).ToList();
            var topicReplyFromDB = topicReplies.FirstOrDefault(t => t.TopicReplyId == id);
            if (topicReplyFromDB == null)
            {
                return NotFound();
            }
            topicReplyFromDB.Topic.NoOfReplies--;
            _db.TopicReplies.Remove(topicReplyFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentTopic") });
        }

        public IActionResult ToggleLikeTopicReply(int id)
        {
            var topicReplyRatingFromDB = _db.TopicReplyRatings.FirstOrDefault(t => t.TopicReplyId == id && t.UserId == HttpContext.Session.GetInt32("currentUser"));
            TopicReply = _db.TopicReplies.FirstOrDefault(t => t.TopicReplyId == id);
            if (topicReplyRatingFromDB == null)
            {
                topicReplyRatingFromDB = new TopicReplyRating
                {
                    TopicReply = TopicReply,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = true
                };
                _db.TopicReplyRatings.Add(topicReplyRatingFromDB);
                TopicReply.LikeCount++;
            }
            else if (!topicReplyRatingFromDB.IsLike)
            {
                topicReplyRatingFromDB.IsLike = true;
                TopicReply.DislikeCount--;
                TopicReply.LikeCount++;
            }
            else if (topicReplyRatingFromDB.IsLike)
            {
                TopicReply.LikeCount--;
                _db.TopicReplyRatings.Remove(topicReplyRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentTopic") });
        }

        public IActionResult ToggleDislikeTopic(int id)
        {
            var topicReplyRatingFromDB = _db.TopicReplyRatings.FirstOrDefault(t => t.TopicReplyId == id && t.UserId == HttpContext.Session.GetInt32("currentUser"));
            TopicReply = _db.TopicReplies.FirstOrDefault(t => t.TopicReplyId == id);
            if (topicReplyRatingFromDB == null)
            {
                topicReplyRatingFromDB = new TopicReplyRating
                {
                    TopicReply = TopicReply,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = false
                };
                _db.TopicReplyRatings.Add(topicReplyRatingFromDB);
                TopicReply.DislikeCount++;
            }
            else if (topicReplyRatingFromDB.IsLike)
            {
                topicReplyRatingFromDB.IsLike = true;
                TopicReply.DislikeCount++;
                TopicReply.LikeCount--;
            }
            else if (!topicReplyRatingFromDB.IsLike)
            {
                TopicReply.DislikeCount--;
                _db.TopicReplyRatings.Remove(topicReplyRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentTopic") });
        }

        public IActionResult RemoveTopicRating(int id)
        {
            var topicReplyRatingFromDB = _db.TopicReplyRatings.FirstOrDefault(t => t.TopicReplyId == id && t.UserId == HttpContext.Session.GetInt32("currentUser"));
            if (topicReplyRatingFromDB == null)
            {
                return NotFound();
            }
            _db.TopicReplyRatings.Remove(topicReplyRatingFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentTopic") });
        }
    }
}
