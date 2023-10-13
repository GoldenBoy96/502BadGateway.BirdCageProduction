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
    public class IndexModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public IndexModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        public IList<ProductionPlan> ProductionPlan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductionPlans != null)
            {
                ProductionPlan = await _context.ProductionPlans
                .Include(p => p.Account)
                .Include(p => p.OrderDetail).ToListAsync();
            }
        }
    }
}
