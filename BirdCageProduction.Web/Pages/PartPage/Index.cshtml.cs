using BusinessLogic.Constant.StatusConstant;
using BusinessLogic.Models.Part;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace BirdCageProduction.Web.Pages.PartPage
{
    public class IndexModel : PageModel
    {
        private readonly IPartService _partService;
        private readonly IColorService _colorService;

        public IndexModel(IPartService partService, IColorService colorService)
        {
            _partService = partService;
            _colorService = colorService;
        }




        // ===================================================================================== //

        [BindProperty]
        public List<Part> Parts { get; set; }

        [BindProperty]
        public PartOptions PartOptions { get; set; }

        //[BindProperty]
        //public Part Part { get; set; }

        [BindProperty]
        public string Color { get; set; }

        // ===================================================================================== //

        public PartPageModel PartModel {  get; set; }

        public SelectList Materials {  get; set; }
        public SelectList Shapes { get; set; }
        public SelectList Sizes { get; set; }

        public SelectList Colors { get; set; }

        // ===================================================================================== //
        public async Task OnGet()
        {
            Parts = _partService.GetParts().Result.ToList();
            PartOptions = _partService.GetPartOptions().Result;

            Materials = new SelectList(PartOptions.Materials);
            Shapes = new SelectList(PartOptions.Shapes);
            Sizes = new SelectList(PartOptions.Sizes);
            Colors = new SelectList(await _colorService.ListColorName());
        }

        public async Task<IActionResult> OnPostAdd()
        {
            _partService.AddPart(PartModel);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit(int id)
        {
            
            return RedirectToPage();
        }
    }
}
