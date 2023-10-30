using BusinessLogic.Constant.StatusConstant;
using BusinessLogic.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.UnitOfWork;

namespace BirdCageProduction.Web.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        private readonly IStatusConstant _statusConstant;

        public IndexModel(IStatusConstant statusConstant)
        {
            _statusConstant = statusConstant;
<<<<<<< HEAD
=======
            //_statusConstant = new StatusConstant();
>>>>>>> bf440a8fbe0b468e055f82b4bbbdd07eb86a0200
        }

        public void OnGet()
        {

            _statusConstant.PrintAccountStatus();
            //StatusConstant.Instance.PrintAccountStatus();
        }
    }
}
