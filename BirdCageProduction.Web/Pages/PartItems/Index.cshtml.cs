using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.PartItems
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public IndexModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        public IList<PartItem> PartItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PartItems != null)
            {
                PartItem = await _context.PartItems
                .Include(p => p.BirdCageCategory)
                .Include(p => p.Part).ToListAsync();
            }
        }
    }
}
