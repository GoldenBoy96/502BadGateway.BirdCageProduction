using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProcedureSteps
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DetailsModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

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
    }
}
