using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;

namespace BirdCageProduction.Web.Pages.ProcedurePage
{
    public class DeleteModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DeleteModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Procedure Procedure { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Procedures == null)
            {
                return NotFound();
            }

            var procedure = await _context.Procedures.FirstOrDefaultAsync(m => m.ProcedureId == id);

            if (procedure == null)
            {
                return NotFound();
            }
            else 
            {
                Procedure = procedure;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Procedures == null)
            {
                return NotFound();
            }
            var procedure = await _context.Procedures.FindAsync(id);

            if (procedure != null)
            {
                Procedure = procedure;
                _context.Procedures.Remove(Procedure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
