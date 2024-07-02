using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;
using System.Security.Claims;
using wbzf.DataAccess.Repository;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Model.ViewModel;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Applications
{
    // [BindProperties]
    [Authorize(Roles = $"{SD.Admin},{SD.Beneficiary},{SD.ScrutinyOfficer},{SD.Manager},{SD.FinanceOfficer}")]

    public class Scheme1Model : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ApplicationRegister appReg { get; set; }
        [BindProperty]
        public CommonUserRgistration Input { get; set; }
        public IEnumerable<SelectListItem> professionlist { get; set; }

        public Scheme1Model(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IWebHostEnvironment hostEnvironment)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;
            _unitOfWork = unitOfWork;
            appReg = new();
            Input = new();
        }
        private IEnumerable<SelectListItem> getprofessionlist()
        {
            var list = _unitOfWork.profession.GetAll(orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
        }
        private async Task LoadAsync(ApplicationUser user)
        {
            //Personal Details From User Table
            Input.Full_Name = user.Full_Name;
            Input.PhoneNumber = user.PhoneNumber;
            Input.Email = user.Email;
            Input.ProfessionId = user.ProfessionId;
            Input.DateofBirth = user.DateofBirth;
            Input.category = user.CastCategory;
            Input.Gender = user.Gender;
            Input.adhaarno = user.adhaar_no;
            Input.ImageUrl = user.ImageUrl;

            //Address Details From User Table
            Input.Vill = user.Vill;
            Input.PostOffice = user.PostOffice;
            Input.PoliceStation = user.PoliceStation;
            Input.District = user.District;
            Input.State = user.State;
            Input.PIN = user.PIN;

            //Family Details From User Table
            Input.FatherName = user.FatherName;
            Input.Mother_Name = user.Mother_Name;
            Input.guardianName = user.guardianName;
            Input.fatherIncome = user.fatherIncome;
            Input.motherIncome = user.motherIncome;
            Input.guardianIncome = user.guardianIncome;
            Input.fatherOccupationId = user.FatherOccupation_ID;
            Input.motherOccupationId = user.MotherOccupation_ID;
            Input.guardianOccupationId = user.GuardianOccupation_ID;
            Input.relation_with_guardian = user.relation_with_guardian;
            Input.parentType = user.parentType;

            //Family Details From User Table
            Input.bankAcNo = user.bankAcNo;
            Input.bankName = user.bankName;
            Input.bankBranchName = user.bankBranchName;
            Input.bankIFSC = user.bankIFSC;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            await LoadAsync(user);
           // appReg = _unitOfWork.applicationRegister.GetFirstOrDefault(u => u.ApplicationUserId == user.Id && u.SchemeId==1 && u.PurposeId==2);
            professionlist = getprofessionlist();
            return Page();
        }
    }
}
