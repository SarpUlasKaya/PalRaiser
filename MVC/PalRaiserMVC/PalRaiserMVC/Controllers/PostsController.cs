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
            List<Post> posts = _db.Posts.ToList();

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
            Post = _db.Posts.FirstOrDefault(p => p.PostId == id && p.PublisherId == HttpContext.Session.GetInt32("profileUser"));
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
                if (Post.PostId == 0)
                {
                    //create
                    Post.Publisher = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                    Post.Date = DateTimeOffset.Now;
                    _db.Posts.Add(Post);
                }
                else
                {
                    Post.Date = DateTimeOffset.Now;
                    _db.Posts.Update(Post);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Post);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var postFromDB = await _db.Posts.FirstOrDefaultAsync(p => p.PostId == id && p.PublisherId == HttpContext.Session.GetInt32("currentUser"));
            if (postFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Posts.Remove(postFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
    }
}
