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
    public class UpsertProjModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertProjModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Project Project { get; set; }

        public async Task<IActionResult> OnGet(int? id) //There may not be an id if we're adding a project
        {
            Project = new Project();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Project = await _db.Project.FirstOrDefaultAsync(u => u.ProjId == id);
            if (Project == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Project.ProjId == 0)
                {
                    _db.Project.Add(Project);
                } else
                {
                    _db.Project.Update(Project);
                }
                //var ProjectFromDB = await _db.Project.FindAsync(Project.ProjId);

                //ProjectFromDB.ProjName = Project.ProjName;
                //ProjectFromDB.Summary = Project.Summary;
                //ProjectFromDB.DetailedInfo = Project.DetailedInfo;
                //ProjectFromDB.Type = Project.Type;
                //ProjectFromDB.AmountRaised = Project.AmountRaised;
                //ProjectFromDB.LikeCount = Project.LikeCount;
                //ProjectFromDB.DislikeCount = Project.DislikeCount;
                //ProjectFromDB.ReportCount = Project.ReportCount;
                //ProjectFromDB.TestValue = Project.TestValue;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
