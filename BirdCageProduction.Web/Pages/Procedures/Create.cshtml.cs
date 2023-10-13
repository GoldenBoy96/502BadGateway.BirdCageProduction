using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;

namespace BirdCageProduction.Web.Pages.Procedures
{
    public class CreateModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public CreateModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BirdCageCategoryId"] = new SelectList(_context.BirdCageCategories, "BirdCageCategoryId", "BirdCageCategoryId");
            return Page();
        }

        [BindProperty]
        public Procedure Procedure { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Procedures == null || Procedure == null)
            {
                return Page();
            }

            _context.Procedures.Add(Procedure);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
