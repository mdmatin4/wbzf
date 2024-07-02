using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Applications
{

    [Authorize(Roles = $"{SD.Admin},{SD.Beneficiary},{SD.ScrutinyOfficer},{SD.Manager},{SD.FinanceOfficer}")]

    public class PreviewApplicationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        // private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ApplicationRegister appReg { get; set; }
        public string purpose { get; set; }
        public bool is_admin { get; set; } = false;
        public bool is_manager { get; set; } = false;
        public bool is_beneficiary { get; set; } = false;
        public bool is_donor { get; set; } = false;
        public bool is_scrutinyOfficer { get; set; } = false;
        public bool is_financeOfficer { get; set; } = false;
        public PreviewApplicationModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> OnGetAsync(string purpose, string id)
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

            this.purpose = purpose.ToLower();
            appReg = _unitOfWork.applicationRegister.GetFirstOrDefault(u => u.Id == id && u.application_Status != SD.Draft, includeProperties: "Scheme,Profession,fatherOccupation,motherOccupation,guardianOccupation,R1MemberOccupation,R2MemberOccupation");
            return Page();
        }
        
    }

}
