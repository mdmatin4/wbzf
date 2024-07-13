using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model.ViewModel;
using wbzf.Model;
using wbzf.Utility;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository;
using Microsoft.Extensions.Hosting;

namespace wbzf.Areas.Admin.Pages.Profile
{
    [Authorize(Roles = $"{SD.Beneficiary}")]
    public class FamilyDetailsModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> professionlist { get; set; }
        public FamilyDetailsModel(
            UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork,
            SignInManager<ApplicationUser> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            Input = new();
        }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public CommonUserRgistration Input { get; set; }
        public ApplicationUser user { get; set; }
        private async Task LoadAsync(ApplicationUser user)
        {
            professionlist = getprofessionlist();
            Input.parentType = user.parentType;
            Input.fatherIncome = user.fatherIncome;
            Input.motherIncome = user.motherIncome;
            Input.guardianIncome = user.guardianIncome;
            Input.FatherName = user.FatherName;
            Input.Mother_Name = user.Mother_Name;
            Input.guardianName = user.guardianName;
            Input.guardianOccupationId = user.GuardianOccupation_ID;
            Input.fatherOccupationId = user.FatherOccupation_ID;
            Input.motherOccupationId = user.MotherOccupation_ID;
            Input.relation_with_guardian = user.relation_with_guardian;

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

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        bool changeDate = false;
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Input.parentType = Request.Form["radioInline"].ToString();
            if (Input.parentType != user.parentType)
            {
                changeDate = true;
                user.parentType = Request.Form["radioInline"].ToString();
            }
            //Father Details
            if (user.parentType == SD.Father)
            {
                if (Input.FatherName != user.FatherName)
                {
                    changeDate = true;
                    user.FatherName = Input.FatherName;

                }
                if (Input.fatherIncome != user.fatherIncome)
                {
                    changeDate = true;
                    
                    user.fatherIncome = Input.fatherIncome;
                }
                if (Input.fatherOccupationId != user.FatherOccupation_ID)
                {
                    changeDate = true;
                    user.FatherOccupation_ID = Input.fatherOccupationId;
                }
               
            }
            //Mother Details
            if (user.parentType == SD.Mother)
            {
                if (Input.Mother_Name != user.Mother_Name)
                {
                    changeDate = true;
                    user.Mother_Name = Input.Mother_Name;
                }
                if (Input.motherIncome != user.motherIncome)
                {
                    changeDate = true;
                    user.motherIncome = Input.motherIncome;
                }
                if (Input.motherOccupationId != user.MotherOccupation_ID)
                {
                    changeDate = true;
                    user.MotherOccupation_ID = Input.motherOccupationId;
                }
            }

            //Guardian Details
            if (user.parentType == SD.Guardian)
            {
                if (Input.guardianName != user.guardianName)
                {
                    changeDate = true;
                    user.guardianName = Input.guardianName;
                   
                }
                if (Input.guardianIncome != user.guardianIncome)
                {
                    changeDate = true;
                    user.guardianIncome = Input.guardianIncome;
                    
                }
                if (Input.guardianOccupationId != user.GuardianOccupation_ID)
                {
                    changeDate = true;
                    user.GuardianOccupation_ID = Input.guardianOccupationId;
                   
                }
                if (Input.relation_with_guardian != user.relation_with_guardian)
                {
                    changeDate = true;
                    user.relation_with_guardian = Input.relation_with_guardian;
                }
            }
            if (changeDate)
            {
                var updateUserSTatus = await _userManager.UpdateAsync(user);
                if (!updateUserSTatus.Succeeded)
                {
                    TempData["delete"] = "Unexpected error when trying to update the profile details.";
                    return RedirectToPage();
                }
            }
          //  await _signInManager.RefreshSignInAsync(user);
            TempData["success"] = "Your family details has been updated successfully.";
            return RedirectToPage();
        }

    }
}
