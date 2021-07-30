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
    public class PostsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Post Post { get; set; }

        public PostsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Post> posts = _db.Posts.Include(p => p.Publisher).ToList();

            return View(posts);
        }

        public IActionResult UpsertPost(int? id)
        {
            Post = new Post();
            if (id == null)
            {
                //create
                return View(Post);
            }
            //update
            Post = _db.Posts.FirstOrDefault(p => p.PostId == id);
            if (Post == null)
            {
                return NotFound();
            }
            return View(Post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertPost()
        {
            if (ModelState.IsValid)
            {
                Post.Publisher = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                Post.Date = DateTimeOffset.Now;
                if (Post.PostId == 0)
                {
                    //create
                    _db.Posts.Add(Post);
                }
                else
                {
                    _db.Posts.Update(Post);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Post);
        }

        public IActionResult DeletePost(int id)
        {
            var postFromDB = _db.Posts.FirstOrDefault(p => p.PostId == id);
            if (postFromDB == null)
            {
                return NotFound();
            }
            _db.Posts.Remove(postFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ToggleLikePost(int id)
        {
            var postRatingFromDB = _db.PostRatings.FirstOrDefault(p => p.PostId == id && p.UserId == HttpContext.Session.GetInt32("currentUser"));
            Post = _db.Posts.FirstOrDefault(p => p.PostId == id);
            if (postRatingFromDB == null)
            {
                postRatingFromDB = new PostRating
                {
                    Post = Post,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = true
                };
                _db.PostRatings.Add(postRatingFromDB);
                Post.LikeCount++;
            }
            else if (!postRatingFromDB.IsLike)
            {
                postRatingFromDB.IsLike = true;
                Post.DislikeCount--;
                Post.LikeCount++;
            }
            else if (postRatingFromDB.IsLike)
            {
                Post.LikeCount--;
                _db.PostRatings.Remove(postRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ToggleDislikePost(int id)
        {
            var postRatingFromDB = _db.PostRatings.FirstOrDefault(p => p.PostId == id && p.UserId == HttpContext.Session.GetInt32("currentUser"));
            Post = _db.Posts.FirstOrDefault(p => p.PostId == id);
            if (postRatingFromDB == null)
            {
                postRatingFromDB = new PostRating
                {
                    Post = Post,
                    User = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser")),
                    IsLike = false
                };
                _db.PostRatings.Add(postRatingFromDB);
                Post.DislikeCount++;
            }
            else if (postRatingFromDB.IsLike)
            {
                postRatingFromDB.IsLike = false;
                Post.DislikeCount++;
                Post.LikeCount--;
            }
            else if (!postRatingFromDB.IsLike)
            {
                Post.DislikeCount--;
                _db.PostRatings.Remove(postRatingFromDB);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemovePostRating(int id)
        {
            var postRatingFromDB = _db.PostRatings.FirstOrDefault(p => p.PostId == id && p.UserId == HttpContext.Session.GetInt32("currentUser"));
            if (postRatingFromDB == null)
            {
                return NotFound();
            }
            _db.PostRatings.Remove(postRatingFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
