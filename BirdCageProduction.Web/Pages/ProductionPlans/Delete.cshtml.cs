using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProductionPlans
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DeleteModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ProductionPlan ProductionPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductionPlans == null)
            {
                return NotFound();
            }

            var productionplan = await _context.ProductionPlans.FirstOrDefaultAsync(m => m.ProductionPlanId == id);

            if (productionplan == null)
            {
                return NotFound();
            }
            else 
            {
                ProductionPlan = productionplan;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductionPlans == null)
            {
                return NotFound();
            }
            var productionplan = await _context.ProductionPlans.FindAsync(id);

            if (productionplan != null)
            {
                ProductionPlan = productionplan;
                _context.ProductionPlans.Remove(ProductionPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
