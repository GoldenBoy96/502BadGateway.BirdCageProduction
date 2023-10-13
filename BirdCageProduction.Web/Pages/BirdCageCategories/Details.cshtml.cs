﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;

namespace BirdCageProduction.Web.Pages.BirdCageCategories
{
    public class DetailsModel : PageModel
    {
        private readonly DataAccess.BirdCageProductionContext _context;

        public DetailsModel(DataAccess.BirdCageProductionContext context)
        {
            _context = context;
        }

      public BirdCageCategory BirdCageCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BirdCageCategories == null)
            {
                return NotFound();
            }

            var birdcagecategory = await _context.BirdCageCategories.FirstOrDefaultAsync(m => m.BirdCageCategoryId == id);
            if (birdcagecategory == null)
            {
                return NotFound();
            }
            else 
            {
                BirdCageCategory = birdcagecategory;
            }
            return Page();
        }
    }
}