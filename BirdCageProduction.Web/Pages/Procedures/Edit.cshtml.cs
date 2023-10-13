using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.Procedures
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public EditModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Procedure Procedure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Procedures == null)
            {
                return NotFound();
            }

            var procedure =  await _context.Procedures.FirstOrDefaultAsync(m => m.ProcedureId == id);
            if (procedure == null)
            {
                return NotFound();
            }
            Procedure = procedure;
           ViewData["BirdCageCategoryId"] = new SelectList(_context.BirdCageCategories, "BirdCageCategoryId", "BirdCageCategoryId");
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

            _context.Attach(Procedure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureExists(Procedure.ProcedureId))
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

        private bool ProcedureExists(int id)
        {
          return (_context.Procedures?.Any(e => e.ProcedureId == id)).GetValueOrDefault();
        }
    }
}
