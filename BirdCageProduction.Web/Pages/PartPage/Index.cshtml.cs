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
        public List<PartPageModel> Parts { get; set; }

        [BindProperty]
        public PartOptions PartOptions { get; set; }

        //[BindProperty]
        //public Part Part { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public PartPageModel? PartModel {  get; set; } = new PartPageModel();

        public SelectList Materials {  get; set; }
        public SelectList Shapes { get; set; }
        public SelectList Sizes { get; set; }

        public SelectList Colors { get; set; }

        // ===================================================================================== //
        public async Task<IActionResult> OnGet()
        {
            LoadData();
            return Page();
        }

        public async Task OnPostById(int id)
        {
            LoadData();
            PartModel = await _partService.GetPartById(id);
        }

        public async Task<IActionResult> OnPostAdd()
        {
            await _partService.AddPart(PartModel);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit()
        {
            await _partService.EditPart(PartModel);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _partService.DeletePart(PartModel.PartId);  
            return RedirectToPage();
        }

        public IActionResult OnPostResetPage()
        {
            return RedirectToPage();
        }

        private async Task LoadData()
        {
            Parts = _partService.GetParts().Result.ToList();
            PartOptions = _partService.GetPartOptions().Result;

            Materials = new SelectList(PartOptions.Materials);
            Shapes = new SelectList(PartOptions.Shapes);
            Sizes = new SelectList(PartOptions.Sizes);
            Colors = new SelectList(await _colorService.ListColorName());
        }
    }
}
