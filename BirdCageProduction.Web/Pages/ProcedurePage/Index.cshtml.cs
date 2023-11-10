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

namespace BirdCageProduction.Web.Pages.ProcedurePage
{
    public class IndexModel : PageModel
    {
        private readonly IProcedureService _procedureService;

        public IndexModel(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [BindProperty]
        public List<Procedure> Procedures { get; set; }

        public async Task OnGetAsync()
        {
            LoadData();
        }


        private async void LoadData()
        {
            Procedures = (await _procedureService.GetAllProcedureAsync()).ToList();
        }
    }
}
