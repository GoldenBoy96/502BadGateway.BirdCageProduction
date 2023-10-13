using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.PartItems
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public EditModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PartItem PartItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PartItems == null)
            {
                return NotFound();
            }

            var partitem =  await _context.PartItems.FirstOrDefaultAsync(m => m.PartItemId == id);
            if (partitem == null)
            {
                return NotFound();
            }
            PartItem = partitem;
           ViewData["BirdCageCategoryId"] = new SelectList(_context.BirdCageCategories, "BirdCageCategoryId", "BirdCageCategoryId");
           ViewData["PartId"] = new SelectList(_context.Parts, "PartId", "PartId");
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

            _context.Attach(PartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartItemExists(PartItem.PartItemId))
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

        private bool PartItemExists(int id)
        {
          return (_context.PartItems?.Any(e => e.PartItemId == id)).GetValueOrDefault();
        }
    }
}
