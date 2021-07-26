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

        public IActionResult Index(int postId)
        {
            HttpContext.Session.SetInt32("currentPost", postId);
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
            Comment = _db.Comments.FirstOrDefault(c => c.CommentId == id && c.PostId == HttpContext.Session.GetInt32("currentPost"));
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
                if (Comment.PostId == 0)
                {
                    //create
                    Comment.Post = _db.Posts.FirstOrDefault(p => p.PostId == HttpContext.Session.GetInt32("currentPost"));
                    Comment.Commentor = _db.AppUsers.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("currentUser"));
                    Comment.Date = DateTimeOffset.Now;
                    _db.Comments.Add(Comment);
                }
                else
                {
                    Comment.Date = DateTimeOffset.Now;
                    _db.Comments.Update(Comment);
                }
                _db.SaveChanges();
                return RedirectToAction("Index", new { id = HttpContext.Session.GetInt32("currentPost") });
            }
            return View(Comment);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var commentFromDB = await _db.Comments.FirstOrDefaultAsync(c => c.CommentId == id && c.PostId == HttpContext.Session.GetInt32("currentPost"));
            if (commentFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Comments.Remove(commentFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
    }
}
