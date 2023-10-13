using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProcedureSteps
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
        ViewData["PartItemId"] = new SelectList(_context.PartItems, "PartItemId", "PartItemId");
        ViewData["ProcedureId"] = new SelectList(_context.Procedures, "ProcedureId", "ProcedureId");
            return Page();
        }

        [BindProperty]
        public ProcedureStep ProcedureStep { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProcedureSteps == null || ProcedureStep == null)
            {
                return Page();
            }

            _context.ProcedureSteps.Add(ProcedureStep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
