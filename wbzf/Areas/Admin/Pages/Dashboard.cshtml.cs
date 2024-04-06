using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace wbzf.Areas.Admin.Pages
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager},{SD.Donor},{SD.Beneficiary}")]

    public class DashboardModel : PageModel
    {
        public bool showData { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public int total_wbcs_applicant,total_wbjs_applicant;
        public donation donation;
        public IEnumerable<Account> Funds { get; set; }
        public IEnumerable<SelectListItem> purposes { get; set; }
        public DashboardModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (User.IsInRole(SD.Donor))
            {
                purposes=_unitOfWork.purpose.GetAll(u => u.IsActive, orderby: u => u.OrderBy(u => u.Order)).Select(u => new SelectListItem
                {
                    Text= u.Name,
                    Value=u.Id.ToString(),
                    Selected=u.IsDefault
                }) ;
                Funds=_unitOfWork.account.GetAll(u => u.isvisibletoPublic==true && u.is_deleted!=true);
            }
            
            
            return Page();
        }

 
    
    }
}
