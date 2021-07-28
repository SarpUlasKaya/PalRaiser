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

        [HttpDelete]
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
    }
}
