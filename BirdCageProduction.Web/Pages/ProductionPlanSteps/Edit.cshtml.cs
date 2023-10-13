using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProductionPlanSteps
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public EditModel(DataAccess.BirdCageProductionContext context)
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

            var productionplanstep =  await _context.ProductionPlanSteps.FirstOrDefaultAsync(m => m.ProductionPlanStepId == id);
            if (productionplanstep == null)
            {
                return NotFound();
            }
            ProductionPlanStep = productionplanstep;
           ViewData["ProcedureStepId"] = new SelectList(_context.ProcedureSteps, "ProcedureStepId", "ProcedureStepId");
           ViewData["ProductionPlanId"] = new SelectList(_context.ProductionPlans, "ProductionPlanId", "ProductionPlanId");
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

            _context.Attach(ProductionPlanStep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionPlanStepExists(ProductionPlanStep.ProductionPlanStepId))
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

        private bool ProductionPlanStepExists(int id)
        {
          return (_context.ProductionPlanSteps?.Any(e => e.ProductionPlanStepId == id)).GetValueOrDefault();
        }
    }
}
