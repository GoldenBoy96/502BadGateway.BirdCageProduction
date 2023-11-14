using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccess;
using BusinessLogic.Service.Abstraction;
using BusinessLogic.Service.Implementation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace BirdCageProduction.Web.Pages.ProcedurePage
{
    public class IndexModel : PageModel
    {
        private readonly IProcedureService _procedureService;
        private readonly IBirdCageService _birdCageService;

        public IndexModel(IProcedureService procedureService, IBirdCageService birdCageService)
        {
            _procedureService = procedureService;
            _birdCageService = birdCageService;
        }

        [BindProperty]
        public List<Procedure>? Procedures { get; set; }

        [BindProperty]
        public Procedure? Procedure { get; set; }

        [BindProperty]
        public List<BirdCage>? BirdCages { get; set; }

        [BindProperty]
        public List<ProcedureStep> ProcedureSteps { get; set; } = new();

        public async Task OnGetAsync()
        {           
            await LoadData();
        }

        public async Task OnPostById(int id)
        {
            await LoadData();
            Procedure = await _procedureService.GetProcedureByIdAsync(id);
            ProcedureSteps = Procedure.ProcedureSteps.ToList();
        }
        
        public async Task<IActionResult> OnPostAdd()
        {
            if (Procedure != null && ProcedureSteps != null) 
            {
                Procedure.ProcedureSteps = ProcedureSteps;
                await _procedureService.AddProcedureAsync(Procedure);
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            if (Procedure != null)
            {
                await _procedureService.DeleteProcedureAsync(Procedure.ProcedureId);
                return RedirectToPage("./Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (Procedure != null)
            {
                await _procedureService.UpdateProcedureAsync(Procedure, ProcedureSteps);
                return RedirectToPage();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostReset()
        {
            return RedirectToPage("./Index");
        }

        private async Task LoadData()
        {
            Procedures = (await _procedureService.GetAllProcedureAsync()).ToList();            
            BirdCages = (await _birdCageService.GetBirdCages()).ToList();
            ViewData["BirdCages"] = new SelectList(await _birdCageService.GetBirdCages(), "BirdCageId", "Name");
        }
    }
}
