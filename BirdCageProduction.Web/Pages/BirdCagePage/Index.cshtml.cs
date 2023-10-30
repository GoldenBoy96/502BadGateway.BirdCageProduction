using BusinessLogic.Models.Part;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirdCageProduction.Web.Pages.BirdCagePage;

public class IndexModel : PageModel
{
    private readonly IBirdCageService birdCageService;
    private readonly IPartItemService partItemService;

    // ========================================================================== //
    [BindProperty]
    public List<PartItem>? PartItems { get; set; }

    [BindProperty]
    public List<BirdCage>? BirdCages { get; set; }

    public BirdCage? BirdCage { get; set; }

    public SelectList selectListPartItems { get; set; } 



    public IndexModel(IBirdCageService birdCageService, IPartItemService partItemService)
    {
        this.birdCageService = birdCageService;
        this.partItemService = partItemService;
    }

    public async Task<IActionResult> OnGet()
    {
        LoadData();
        return Page();
    }

    public async Task<IActionResult> OnPostById(int id)
    {
        BirdCage = await birdCageService.GetBirdCageById(id);
        LoadData();
        return Page();
    }

    private void LoadData()
    {
        BirdCages = birdCageService.GetBirdCages().Result.ToList();
    }

}
