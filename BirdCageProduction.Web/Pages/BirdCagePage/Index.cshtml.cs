using BusinessLogic.Models.Part;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdCageProduction.Web.Pages.BirdCagePage
{
    public class IndexModel : PageModel
    {
        private readonly IBirdCageService birdCageService;
        private readonly IPartItemService partItemService;

        // ========================================================================== //
        [BindProperty]
        public List<PartItem> PartItems { get; set; }



        public IndexModel(IBirdCageService birdCageService, IPartItemService partItemService)
        {
            this.birdCageService = birdCageService;
            this.partItemService = partItemService;
        }

        public async Task<IActionResult> OnGet()
        {
            LoadData();
            return RedirectToPage();
        }


        private void LoadData()
        {
            
        }

    }
}
