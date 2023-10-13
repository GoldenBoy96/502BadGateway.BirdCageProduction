using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.BirdCageCategories
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public EditModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BirdCageCategory BirdCageCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BirdCageCategories == null)
            {
                return NotFound();
            }

            var birdcagecategory =  await _context.BirdCageCategories.FirstOrDefaultAsync(m => m.BirdCageCategoryId == id);
            if (birdcagecategory == null)
            {
                return NotFound();
            }
            BirdCageCategory = birdcagecategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BirdCageCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdCageCategoryExists(BirdCageCategory.BirdCageCategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BirdCageCategoryExists(int id)
        {
          return (_context.BirdCageCategories?.Any(e => e.BirdCageCategoryId == id)).GetValueOrDefault();
        }
    }
}
