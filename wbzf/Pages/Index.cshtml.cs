using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace wbzf.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IList<Customer> customerList;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            customerList = new List<Customer>();
        }
        public async Task<IActionResult> OnPostInsertCustomers([FromBody] List<Customer> customers)
        {
            int numberofCustomer = 0;
            //Check for NULL.
            if (customers == null)
            {
                customers = new List<Customer>();
            }

            //Loop and insert records.
            foreach (var customer in customers)
            {
                numberofCustomer++;
            }

            return Content(numberofCustomer.ToString());
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}