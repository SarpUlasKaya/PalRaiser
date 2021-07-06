using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalRaiserRazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalRaiserRazor.Controllers
{
    [Route("api/Project")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Project.ToListAsync() });
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var projectFromDB = await _db.Project.FirstOrDefaultAsync(u => u.ProjId == id);
            if (projectFromDB == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }
            _db.Project.Remove(projectFromDB);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Deletion successful" });
        }
    }
}
