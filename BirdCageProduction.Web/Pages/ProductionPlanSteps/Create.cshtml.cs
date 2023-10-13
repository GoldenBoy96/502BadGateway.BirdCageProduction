using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProductionPlanSteps
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
        ViewData["ProcedureStepId"] = new SelectList(_context.ProcedureSteps, "ProcedureStepId", "ProcedureStepId");
        ViewData["ProductionPlanId"] = new SelectList(_context.ProductionPlans, "ProductionPlanId", "ProductionPlanId");
            return Page();
        }

        [BindProperty]
        public ProductionPlanStep ProductionPlanStep { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProductionPlanSteps == null || ProductionPlanStep == null)
            {
                return Page();
            }

            _context.ProductionPlanSteps.Add(ProductionPlanStep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
