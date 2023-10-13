using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;

namespace BirdCageProduction.Web.Pages.PartItems
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
        ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId");
            return Page();
        }

        [BindProperty]
        public PartItem PartItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PartItems == null || PartItem == null)
            {
                return Page();
            }

            _context.PartItems.Add(PartItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
