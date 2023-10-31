using BusinessLogic.Models.Part;
using BusinessLogic.Models.PartItem;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.UnitOfWork;

namespace BirdCageProduction.Web.Pages.BirdCagePage;

public class IndexModel : PageModel
{
    private readonly IBirdCageService birdCageService;
    private readonly IPartItemService partItemService;
    private readonly IPartService partService;

    // ========================================================================== //
    [BindProperty]
    public List<PartItem>? PartItems { get; set; }

    [BindProperty]
    public List<PartItemPageModel> PartItemPages { get; set; } = new List<PartItemPageModel>();

    [BindProperty]
    public List<BirdCage>? BirdCages { get; set; }

    [BindProperty]
    public BirdCage? BirdCage { get; set; }

    public PartItem? PartItem { get; set; }

    public SelectList selectListPartItems { get; set; }

    public SelectList PartCode {  get; set; }


    // ========================================================================== //

    public IndexModel(IBirdCageService birdCageService, IPartItemService partItemService, IPartService partService)
    {
        this.birdCageService = birdCageService;
        this.partItemService = partItemService;
        this.partService = partService;
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

    public async Task<IActionResult> OnPostAdd()
    {
        _ = birdCageService.Add(BirdCage, PartItemPages);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostAddPartItem(int partId, int quantity)
    {
        throw new NotImplementedException();
    }


    private void LoadData()
    {
        BirdCages = birdCageService.GetBirdCages().Result.ToList();
        PartCode = new SelectList(partService.PartCodes().Result.ToList());
    }

}
