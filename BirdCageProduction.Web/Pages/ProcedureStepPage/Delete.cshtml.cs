using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProcedureStepPage
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DeleteModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProcedureStep ProcedureStep { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProcedureSteps == null)
            {
                return NotFound();
            }

            var procedurestep = await _context.ProcedureSteps.FirstOrDefaultAsync(m => m.ProcedureStepId == id);

            if (procedurestep == null)
            {
                return NotFound();
            }
            else 
            {
                ProcedureStep = procedurestep;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProcedureSteps == null)
            {
                return NotFound();
            }
            var procedurestep = await _context.ProcedureSteps.FindAsync(id);

            if (procedurestep != null)
            {
                ProcedureStep = procedurestep;
                _context.ProcedureSteps.Remove(ProcedureStep);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
