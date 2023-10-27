using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace BirdCageProduction.Web.Pages.Part
{
    public class IndexModel : PageModel
    {
        


        // ===================================================================================== //

        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]
        public string? Description { get; set; }
        [BindProperty]
        public string? Shape { get; set; }
        [BindProperty]
        public string? Material { get; set; }
        [BindProperty]
        public string? Size { get; set; }
        [BindProperty] 
        public string? Color { get; set; }
        [BindProperty]
        public int Cost { get; set; }

        // ===================================================================================== //
        public void OnGet()
        {
        }
    }
}
