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

namespace wbzf.Areas.Admin.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IWebHostEnvironment _hostEnvironment;
        private IUnitOfWork _unitofWork;
        public IndexModel(IUnitOfWork unitOfWork,
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
        public CommonUserRgistration Input { get; set; }
        public IEnumerable<SelectListItem> professionlist { get; set; }
        private async Task LoadAsync(ApplicationUser user)
        {

            Input.Full_Name = user.Full_Name;
            if (User.IsInRole(SD.Admin))
            {
                Input.Email = await _userManager.GetEmailAsync(user);
                Input.PhoneNumber = user.PhoneNumber;
            }
            else
            {
                Input.PhoneNumber = await _userManager.GetPhoneNumberAsync(user);
                Input.Email = user.Email;
            }
            Input.ProfessionId = user.ProfessionId;
            Input.DateofBirth = user.DateofBirth;
            Input.category = user.CastCategory;
            Input.Gender = user.Gender;
            Input.adhaarno = user.adhaar_no;
            Input.ImageUrl = user.ImageUrl;
            Input.Vill = user.Vill;
            Input.PostOffice = user.PostOffice;
            Input.PoliceStation = user.PoliceStation;
            Input.District = user.District;
            Input.State = user.State;
            Input.PIN = user.PIN;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            professionlist = getprofessionlist();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }
        private IEnumerable<SelectListItem> getprofessionlist()
        {
            var list = _unitofWork.profession.GetAll(orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
        }
        bool changeDate = false;
        public async Task<IActionResult> OnPostAsync()
        {
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new;
            var uploads = Path.Combine(webRootPath, @"images/user");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
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

            if (Input.Full_Name != user.Full_Name)
            {
                changeDate = true;
                user.Full_Name = Input.Full_Name;
            }
            if (Input.adhaarno != user.adhaar_no)
            {
                changeDate = true;
                user.adhaar_no = Input.adhaarno;
            }
            if (Input.category != user.CastCategory)
            {
                changeDate = true;
                user.CastCategory = Input.category;
            }
            if (Input.Gender != user.Gender)
            {
                changeDate = true;
                user.Gender = Input.Gender;
            }
            if (Input.ProfessionId != user.ProfessionId)
            {
                changeDate = true;
                user.ProfessionId = Input.ProfessionId;
            }
            if (Input.DateofBirth != user.DateofBirth)
            {
                changeDate = true;
                user.DateofBirth = Input.DateofBirth;
            }

            if (Input.Vill != user.Vill)
            {
                changeDate = true;
                user.Vill = Input.Vill;
            }
            if (Input.PostOffice != user.PostOffice)
            {
                changeDate = true;
                user.PostOffice = Input.PostOffice;

            }
            if (Input.PoliceStation != user.PoliceStation)
            {
                changeDate = true;
                user.PoliceStation = Input.PoliceStation;
            }
            if (Input.District != user.District)
            {
                changeDate = true;
                user.District = Input.District;
            }
            if (Input.State != user.State)
            {
                changeDate = true;
                user.State = Input.State;
            }
            if (Input.PIN != user.PIN)
            {
                changeDate = true;
                user.PIN = Input.PIN;
            }
            if (files.Count > 0)
            {
                changeDate = false;
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, user.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                user.ImageUrl = @"\images\user\" + user.Id + extension;
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
            TempData["success"] = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
