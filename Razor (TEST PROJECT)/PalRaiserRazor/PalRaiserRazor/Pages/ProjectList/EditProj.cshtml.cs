using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PalRaiserRazor.Model;

namespace PalRaiserRazor.Pages.ProjectList
{
    public class EditProjModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditProjModel( ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task OnGet(int id)
        {
            Project = await _db.Project.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProjectFromDB = await _db.Project.FindAsync(Project.ProjId);

                ProjectFromDB.ProjName = Project.ProjName;
                ProjectFromDB.Summary = Project.Summary;
                ProjectFromDB.DetailedInfo = Project.DetailedInfo;
                ProjectFromDB.Type = Project.Type;
                ProjectFromDB.AmountRaised = Project.AmountRaised;
                ProjectFromDB.LikeCount = Project.LikeCount;
                ProjectFromDB.DislikeCount = Project.DislikeCount;
                ProjectFromDB.ReportCount = Project.ReportCount;
                ProjectFromDB.TestValue = Project.TestValue;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
