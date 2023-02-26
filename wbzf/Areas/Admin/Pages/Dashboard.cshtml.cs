using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace wbzf.Areas.Admin.Pages
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager},{SD.Donor},{SD.Beneficiary}")]

    public class DashboardModel : PageModel
    {
        public bool showData { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public int total_wbcs_applicant,total_wbjs_applicant;

        public DashboardModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            
            if (User.IsInRole(SD.Admin)||User.IsInRole(SD.Manager))
            {
                showData= true;
                var applications = _unitOfWork.coachingApplication.GetAll();
                total_wbcs_applicant=applications.Where(u => u.exam_name==SD.WBCS).Count();
                total_wbjs_applicant=applications.Where(u => u.exam_name==SD.WBJS).Count();
            }
            else
            {
                showData= false;
            }
            
            return Page();
        }
    }
}
