using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProductionPlans
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
        ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
        ViewData["OrderDetailId"] = new SelectList(_context.OrderDetails, "OrderDetailId", "OrderDetailId");
            return Page();
        }

        [BindProperty]
        public ProductionPlan ProductionPlan { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProductionPlans == null || ProductionPlan == null)
            {
                return Page();
            }

            _context.ProductionPlans.Add(ProductionPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
