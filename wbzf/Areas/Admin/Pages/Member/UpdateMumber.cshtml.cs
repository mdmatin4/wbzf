using wbzf.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using wbzf.Model.ViewModel;
using wbzf.DataAccess.Repository.IRepository;
using System.Security.Claims;
using wbzf.Utility;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository;

namespace wbzf.Areas.Admin.Pages.Member
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class UpdateMumberModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IWebHostEnvironment _hostEnvironment;
        private IUnitOfWork _unitofWork;
        public UpdateMumberModel(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IWebHostEnvironment hostEnvironment)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;
            _unitofWork = unitOfWork;
            Input = new();
        }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public ApplicationRegister Input { get; set; }
        public IEnumerable<SelectListItem> professionlist { get; set; }
        private async Task LoadAsync(ApplicationUser user)
        {
            Input.Full_Name = user.Full_Name;
            Input.Email = await _userManager.GetEmailAsync(user);
            Input.PhoneNumber = user.PhoneNumber;
            Input.ApplicationUserId = user.Id;

        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);//Hoping that row.Cells[0].Text is username of the user
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

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            if (User.IsInRole(SD.Admin))
            {
                if (Input.Email != user.Email)
                {
                    changeDate = true;
                    user.Email = Input.Email;
                    var setPhoneResult = await _userManager.SetUserNameAsync(user, Input.Email);
                    if (!setPhoneResult.Succeeded)
                    {
                        StatusMessage = "Unexpected error when trying to set phone number.";
                        return RedirectToPage();
                    }
                }
                if (Input.PhoneNumber != user.PhoneNumber)
                {
                    changeDate = true;
                    user.PhoneNumber = Input.PhoneNumber;
                }
            }
            else
            {
                if (Input.PhoneNumber != user.PhoneNumber)
                {
                    changeDate = true;
                    user.PhoneNumber = Input.PhoneNumber;
                    var setPhoneResult = await _userManager.SetUserNameAsync(user, Input.PhoneNumber);
                    if (!setPhoneResult.Succeeded)
                    {
                        StatusMessage = "Unexpected error when trying to set phone number.";
                        return RedirectToPage();
                    }
                }
                if (Input.Email != user.Email)
                {
                    changeDate = true;
                    user.Email = Input.Email;
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

            await _signInManager.RefreshSignInAsync(user);
            TempData["success"] = "Your profile has been updated";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostSetPassowrd(string password)
        {
            var user = await _userManager.FindByIdAsync(Input.ApplicationUserId);//Hoping that row.Cells[0].Text is username of the user
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password.Trim());
            TempData["success"] = "New Password Set Successfully";
            return RedirectToPage(new { id = Input.ApplicationUserId });
        }
    }
}
