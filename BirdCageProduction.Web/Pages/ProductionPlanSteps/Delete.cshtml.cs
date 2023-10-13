using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProductionPlanSteps
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DeleteModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductionPlanStep ProductionPlanStep { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductionPlanSteps == null)
            {
                return NotFound();
            }

            var productionplanstep = await _context.ProductionPlanSteps.FirstOrDefaultAsync(m => m.ProductionPlanStepId == id);

            if (productionplanstep == null)
            {
                return NotFound();
            }
            else 
            {
                ProductionPlanStep = productionplanstep;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductionPlanSteps == null)
            {
                return NotFound();
            }
            var productionplanstep = await _context.ProductionPlanSteps.FindAsync(id);

            if (productionplanstep != null)
            {
                ProductionPlanStep = productionplanstep;
                _context.ProductionPlanSteps.Remove(ProductionPlanStep);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
