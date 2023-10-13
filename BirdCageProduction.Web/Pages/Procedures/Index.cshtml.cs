using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.Procedures
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public IndexModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        public IList<Procedure> Procedure { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Procedures != null)
            {
                Procedure = await _context.Procedures
                .Include(p => p.BirdCageCategory).ToListAsync();
            }
        }
    }
}
