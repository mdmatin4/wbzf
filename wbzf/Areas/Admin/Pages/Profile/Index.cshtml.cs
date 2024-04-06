using wbzf.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace wbzf.Areas.Admin.Pages.Profile
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IWebHostEnvironment _hostEnvironment;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IWebHostEnvironment hostEnvironment)
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
            _hostEnvironment=hostEnvironment;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Display(Name ="User Name")]
            public string UserName { get; set; }
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Mobile number")]
            [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
            public string PhoneNumber { get; set; }
            [Display(Name ="Profile Picture")]
            public string? ImageUrl { get; set; }

            public string? Vill { get; set; }
            public string? PostOffice { get; set; }
            public string? PoliceStation { get; set; }
            public string? District { get; set; }
            public string? State { get; set; }
            public string? PIN { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = user.Full_Name;
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var ProfilePic = user.ImageUrl;
            var vill = user.Vill;
            var postOffice = user.PostOffice;
            var policeStation = user.PoliceStation;
            var district = user.District;
            var state = user.State;
            var pin = user.PIN;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                UserName = userName,
                ImageUrl = ProfilePic,
                Vill = vill,
                PostOffice = postOffice,
                PoliceStation = policeStation,
                District = district,
                State = state,
                PIN = pin
            };
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
        bool changeDate=false;
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

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != user.PhoneNumber)
            {
                changeDate = true;
                user.PhoneNumber=Input.PhoneNumber;
                //var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                //if (!setPhoneResult.Succeeded)
                //{
                //    StatusMessage = "Unexpected error when trying to set phone number.";
                //    return RedirectToPage();
                //}
            }
            if (Input.UserName!=user.Full_Name)
            {
               changeDate=true;
                user.Full_Name=Input.UserName;
            }
            if (Input.Vill!=user.Vill)
            {
                changeDate=true;
                user.Vill=Input.Vill;
            }
            if (Input.PostOffice!=user.PostOffice)
            {
                changeDate=true;
                user.PostOffice=Input.PostOffice;

            }
            if (Input.PoliceStation!=user.PoliceStation)
            {
                changeDate=true;
                user.PoliceStation=Input.PoliceStation;
            }
            if (Input.District!=user.District)
            {
                changeDate=true;
                user.District=Input.District;
            }
            if(Input.State != user.State)
            {
                changeDate=true;
                user.State=Input.State;
            }
            if(Input.PIN != user.PIN)
            {
                changeDate=true;
                user.PIN=Input.PIN;
            }
            if (files.Count > 0)
            {
                changeDate=false;
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
                var setFullname = await _userManager.UpdateAsync(user);
                if (!setFullname.Succeeded)
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
