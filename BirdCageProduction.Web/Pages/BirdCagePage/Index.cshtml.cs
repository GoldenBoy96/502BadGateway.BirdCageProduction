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

        public IndexModel(IBirdCageService birdCageService)
        {
            this.birdCageService = birdCageService;
        }

        public void OnGet()
        {
        }
    }
}
