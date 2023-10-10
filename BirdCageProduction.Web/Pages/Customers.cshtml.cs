using BusinessLogic.IService;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdCageProduction.Web.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly ICustomerService customerService;

        public CustomersModel(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public List<Customer> Customers { get; set; }

        public void OnGet()
        {
             Customers = customerService.GetCustomers.ToList();
        }
    }
}
