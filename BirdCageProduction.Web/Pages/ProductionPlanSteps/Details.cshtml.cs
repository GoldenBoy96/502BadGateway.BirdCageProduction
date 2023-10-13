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
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DetailsModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

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
    }
}
