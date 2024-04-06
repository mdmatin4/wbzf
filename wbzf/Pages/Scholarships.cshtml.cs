using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razorpay.Api;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class ScholarshipsModel : PageModel
    {

        private IUnitOfWork _unitofWork;
        [BindProperty]
        public InputRegisterModel InputModel { get; set; }
        public ApplicationUser user { get; set; }
        public Company company { get; set; }
        //public donation Donation { get; set; }
        public IEnumerable<SelectListItem> professionList { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ScholarshipsModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser>
            userManager, IUserStore<ApplicationUser> userStore, SignInManager<ApplicationUser> signInManager,
            ILogger<ApplicationUser> logger,
            Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _unitofWork=unitOfWork;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }
        public void OnGet()
        {
            professionList=_unitofWork.profession.getProfessionforSelectItem();
            company=_unitofWork.company.GetCompany();
        }


        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            returnUrl ??= Url.Content("~/Admin/Dashboard");
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.Full_Name=InputModel.Full_Name;
                user.PhoneNumber=InputModel.PhoneNumber;
                user.Email=InputModel.Email;
                user.ProfessionId=InputModel.ProfessionId;
                user.Gender=InputModel.Gender;
                user.Mother_Name=InputModel.Mother_Name;
                user.created_at=DateTime.UtcNow.AddHours(5).AddMinutes(30);
                await _userStore.SetUserNameAsync(user, InputModel.PhoneNumber, CancellationToken.None);
                
                var result = await _userManager.CreateAsync(user, InputModel.Password);
                if (result.Succeeded)
                {
                    if (InputModel.Email != null)
                    {
                        try
                        {
                            await _emailStore.SetEmailAsync(user, InputModel.Email, CancellationToken.None);
                            await _emailSender.SendEmailAsync(InputModel.Email, $"Donation Registration Successful : {InputModel.Full_Name}",
                            $"Your registration has been successfully completed . Please login with you Mobile no: {InputModel.PhoneNumber} as username and {InputModel.Password} as Password to login..");
                        }
                        catch (Exception ex) { }
                       

                    }
                    await _userManager.AddToRoleAsync(user, SD.Donor);
                    
                    TempData["success"] = "Your  registration has been successfully completed.";
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                else
                {

                    string error = "";

                    foreach (var item in result.Errors)
                    {
                        error += string.Join(", ", item.Description);
                    }
                    ModelState.AddModelError("", error);
                    TempData["warning"] = error;
                }


            }
            professionList=_unitofWork.profession.getProfessionforSelectItem();
            return Page();
        }
        
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
       

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
