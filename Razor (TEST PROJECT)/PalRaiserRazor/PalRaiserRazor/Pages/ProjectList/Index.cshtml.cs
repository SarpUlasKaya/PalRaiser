using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PalRaiserRazor.Model;

namespace PalRaiserRazor.Pages.ProjectList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Project> Projects { get; set; }

        public async Task OnGet()
        {
            Projects = await _db.Project.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var project = await _db.Project.FindAsync(id);
            if(project == null)
            {
                return NotFound();
            }
            _db.Project.Remove(project);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
