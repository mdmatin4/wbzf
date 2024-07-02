using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model.ViewModel;
using wbzf.Model;
using wbzf.Utility;
using System.Security.Claims;

namespace wbzf.Areas.Admin.Pages.Profile
{
    [Authorize(Roles = $"{SD.Beneficiary},{SD.ScrutinyOfficer},{SD.Manager},{SD.FinanceOfficer}")]
    public class BankingDetailsModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IWebHostEnvironment _hostEnvironment;

        public BankingDetailsModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IWebHostEnvironment hostEnvironment)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment = hostEnvironment;
            Input = new();
        }


        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public CommonUserRgistration Input { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {

            //Input.UserName = await _userManager.GetUserIdAsync(user);
            Input.bankAcNo = user.bankAcNo;
            Input.bankName = user.bankName;
            Input.bankBranchName = user.bankBranchName;
            Input.bankIFSC = user.bankIFSC;
            Input.passbookUrl = user.passbookUrl;

        }
        //  public string ApplicationUserId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //ApplicationUserId = claim.Value;

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
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new;
            var uploads = Path.Combine(webRootPath, @"images/passbook");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (Input.bankAcNo != user.bankAcNo)
            {
                changeDate = true;
                user.bankAcNo = Input.bankAcNo;
            }
            if (Input.bankName != user.bankName)
            {
                changeDate = true;
                user.bankName = Input.bankName;
            }
            if (Input.bankBranchName != user.bankBranchName)
            {
                changeDate = true;
                user.bankBranchName = Input.bankBranchName;
            }
            if (Input.bankIFSC != user.bankIFSC)
            {
                changeDate = true;
                user.bankIFSC = Input.bankIFSC;

            }

            if (files.Count > 0)
            {
                changeDate = false;
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, user.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                user.passbookUrl = @"\images\passbook\" + user.Id + extension;
                await _userManager.UpdateAsync(user);
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
            TempData["success"] = "Your bank details has been updated successfully.";
            return RedirectToPage();
        }

    }
}
