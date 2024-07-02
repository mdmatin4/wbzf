using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace wbzf.Areas.Admin.Pages
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager},{SD.Donor},{SD.Beneficiary},{SD.ScrutinyOfficer},{SD.Manager}")]

    public class DashboardModel : PageModel
    {
        public bool showData { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public int total_wbcs_applicant, total_wbjs_applicant;
        public donation donation;
        public IEnumerable<Account> Funds { get; set; }
        public IEnumerable<ApplicationRegister> appregList { get; set; }
        public Scheme scheme { get; set; }
        public IEnumerable<SelectListItem> purposes { get; set; }
       
        public bool is_admin { get; set; } = false;
        public bool is_manager { get; set; } = false;
        public bool is_beneficiary { get; set; } = false;
        public bool is_donor { get; set; } = false;
        public bool is_scrutinyOfficer { get; set; } = false;
        public bool is_financeOfficer { get; set; } = false;
        public DashboardModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string ApplicationUserId = claim.Value;
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(ApplicationUserId));

            is_admin = roles.Contains(SD.Admin);
            is_manager = roles.Contains(SD.Manager);
            is_beneficiary = roles.Contains(SD.Beneficiary);
            is_donor = roles.Contains(SD.Donor);
            is_scrutinyOfficer = roles.Contains(SD.ScrutinyOfficer);
            is_financeOfficer = roles.Contains(SD.FinanceOfficer);


            if (is_donor)
            {
                purposes = _unitOfWork.purpose.GetAll(u => u.IsActive, orderby: u => u.OrderBy(u => u.Order)).Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                    Selected = u.IsDefault
                });
                Funds = _unitOfWork.account.GetAll(u => u.isvisibletoPublic == true && u.is_deleted != true);
            }
            if (is_beneficiary)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                appregList = _unitOfWork.applicationRegister.GetAll(u => u.ApplicationUserId == user.Id, includeProperties: "Scheme,Purpose");     
            }

            return Page();
        }



    }
}
