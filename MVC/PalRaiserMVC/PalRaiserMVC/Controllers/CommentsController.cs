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
    public class CommentsController : Controller
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Comment Comment { get; set; }

        public CommentsController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            HttpContext.Session.SetInt32("currentPost", id);
            List<Comment> comments = _db.Comments.Include(c => c.Commentor).ToList();

            return View(comments);
        }

        public IActionResult UpsertComment(int? id)
        {
            Comment = new Comment();
            if (id == null)
            {
                //create
                return View(Comment);
            }
            //update
            Comment = _db.Comments.FirstOrDefault(c => c.CommentId == id);
            if (Comment == null)
            {
                return NotFound();
            }
            return View(Comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpsertComment()
        {
            if (ModelState.IsValid)
            {
                Comment.Post = _db.Posts.FirstOrDefault(p => p.PostId == HttpContext.Session.GetInt32("currentPost"));
                Comment.Commentor = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                Comment.Date = DateTimeOffset.Now;
                if (Comment.CommentId == 0)
                {
                    _db.Comments.Add(Comment);
                    Comment.Post.CommentCount++;
                }
                else
                {
                    _db.Comments.Update(Comment);
                }
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentPost") });
            }
            return View(Comment);
        }

        public IActionResult DeleteComment(int id)
        {
            var comments = _db.Comments.Include(c => c.Post).ToList();
            var commentFromDB = comments.FirstOrDefault(c => c.CommentId == id);
            if (commentFromDB == null)
            {
                return NotFound();
            }
            commentFromDB.Post.CommentCount--;
            _db.Comments.Remove(commentFromDB);
            _db.SaveChanges();
            return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentPost") });
        }
    }
}
