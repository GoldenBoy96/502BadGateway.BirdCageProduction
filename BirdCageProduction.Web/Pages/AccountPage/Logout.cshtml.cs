using BusinessLogic.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdCageProduction.Web.Pages.AccountPage
{
    public class LogoutModel : PageModel
    {
        private readonly IAuthService _authService;

        public LogoutModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> OnGet()
        {
            _authService.LogOut();
            return RedirectToPage("/Index");
        }
    }
}
