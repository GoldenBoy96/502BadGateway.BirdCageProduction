using BusinessLogic.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BirdCageProduction.Web.Pages.AccountPage
{
    public class LoginModel : PageModel
    {
        private readonly IAuthService _authService;

        public LoginModel(IAuthService authService)
        {
            _authService = authService;
        }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [BindProperty]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("../Dashboard/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var temp = await _authService.Login(Email, Password);
            if (temp)
            {
                return RedirectToPage("../Dashboard/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
        }
    }
}