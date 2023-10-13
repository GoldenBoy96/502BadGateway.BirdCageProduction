using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProductionPlans
{
    public class EditModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public EditModel(DataAccess.BirdCageProductionContext context)
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

            var productionplan =  await _context.ProductionPlans.FirstOrDefaultAsync(m => m.ProductionPlanId == id);
            if (productionplan == null)
            {
                return NotFound();
            }
            ProductionPlan = productionplan;
           ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
           ViewData["OrderDetailId"] = new SelectList(_context.OrderDetails, "OrderDetailId", "OrderDetailId");
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

            _context.Attach(ProductionPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionPlanExists(ProductionPlan.ProductionPlanId))
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

        private bool ProductionPlanExists(int id)
        {
          return (_context.ProductionPlans?.Any(e => e.ProductionPlanId == id)).GetValueOrDefault();
        }
    }
}
