using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PalRaiserRazor.Model;

namespace PalRaiserRazor.Pages.ProjectList
{
    public class CreateProjModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateProjModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Project Project { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Project.AddAsync(Project);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } else
            {
                return Page();
            }
        }
    }
}
