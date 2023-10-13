using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.BirdCageCategories
{
    public class IndexModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public IndexModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

        public IList<BirdCageCategory> BirdCageCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BirdCageCategories != null)
            {
                BirdCageCategory = await _context.BirdCageCategories.ToListAsync();
            }
        }
    }
}
