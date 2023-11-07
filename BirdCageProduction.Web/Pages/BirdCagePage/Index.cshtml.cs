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

    public PartItemPageModel? PartItem { get; set; }

    public SelectList? PartCode {  get; set; }

    public int index;

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
        foreach (var item in BirdCage.PartItems)
        {
            PartItemPages.Add(new PartItemPageModel
            {
                Code = item.Part.Code,
                Quantity = item.Quantity
            });
        }
        LoadData();
        return Page();
    }

    public async Task<IActionResult> OnPostAdd()
    {
        await birdCageService.Add(BirdCage, PartItemPages);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostEdit()
    {
        await birdCageService.EditBirtCage(BirdCage, PartItemPages);
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDelete()
    {
        await birdCageService.DeleteBirdCage(BirdCage.BirdCageId);
        return RedirectToPage();
    }

    private void LoadData()
    {
        BirdCages = birdCageService.GetBirdCages().Result.ToList();
        PartCode = new SelectList(partService.PartCodes().Result.ToList());
    }

}
