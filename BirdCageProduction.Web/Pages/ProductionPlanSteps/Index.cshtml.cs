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
    public class IndexModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public IndexModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        public IList<ProductionPlanStep> ProductionPlanStep { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductionPlanSteps != null)
            {
                ProductionPlanStep = await _context.ProductionPlanSteps
                .Include(p => p.ProcedureStep)
                .Include(p => p.ProductionPlan).ToListAsync();
            }
        }
    }
}
