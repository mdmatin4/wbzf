using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using wbzf.Model;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.Pages
{
    public class IndexModel : PageModel
    {
        private IUnitOfWork _unitOfWork;

        public Company company { get; set; }
        public IEnumerable<Sponsor> sponsors { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IActionResult> OnGet()
        {
            company=_unitOfWork.company.GetCompany();
            sponsors=_unitOfWork.sponsor.GetAll(orderby: u => u.OrderBy(u => u.displayOrder));
            return Page();
        }
        
    }
}