using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.Parts
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DeleteModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Part Part { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FirstOrDefaultAsync(m => m.PartId == id);

            if (part == null)
            {
                return NotFound();
            }
            else 
            {
                Part = part;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Parts == null)
            {
                return NotFound();
            }
            var part = await _context.Parts.FindAsync(id);

            if (part != null)
            {
                Part = part;
                _context.Parts.Remove(Part);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
