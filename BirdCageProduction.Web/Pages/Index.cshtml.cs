using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BirdCageProduction.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

		public string? FullName { get; set; }
		public string? Role { get; set; }

		public void OnGet()
        {
            var FullNameClaim = User.FindFirst("FullName");
            var RoleClaim = User.FindFirst(ClaimTypes.Role);

			FullName = FullNameClaim?.Value;
            Role = RoleClaim?.Value;
        }
    }
}