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
    public class DonationModel : PageModel
    {

        private IUnitOfWork _unitofWork;
        [BindProperty]
        public InputRegisterModel InputModel { get; set; }
        public ApplicationUser user { get; set; }
        //public donation Donation { get; set; }
        public IEnumerable<SelectListItem> professionList { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DonationModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser>
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
            professionList=getProfessionList();
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
                await _userStore.SetUserNameAsync(user, InputModel.PhoneNumber, CancellationToken.None);
                
                var result = await _userManager.CreateAsync(user, InputModel.Password);
                if (result.Succeeded)
                {
                    if (InputModel.Email != null)
                    {
                        await _emailStore.SetEmailAsync(user, InputModel.Email, CancellationToken.None);
                        await _emailSender.SendEmailAsync(InputModel.Email, $"Donation Registration Successful : {InputModel.Full_Name}",
                        $"Your registration has been successfully completed . Please login with you Mobile no: {InputModel.PhoneNumber} as username and {InputModel.Password} as Password to login..");

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
            professionList=getProfessionList();
            return Page();
        }
        //public IActionResult OnPostPayment(donation donation)
        //{
        //    donation.transaction_id="tempid";
        //    donation.created_at=DateTime.Now;
        //    donation.type="donation";
        //    donation.status=SD.notUtilized;
        //    donation.payment_status=SD.created;
        //    ModelState.Remove("donation.transaction_id");
        //    ModelState.Remove("donation.created_at");
        //    ModelState.Remove("donation.type");

        //    if (ModelState.IsValid)
        //    {
        //        RazorpayClient client = new RazorpayClient(_unitofWork.company.GetRazorpay().key_id, _unitofWork.company.GetRazorpay().key_secret);
        //        Dictionary<string, object> options = new Dictionary<string, object>();
        //        options.Add("amount", donation.amount*100); // amount in the smallest currency unit
        //        options.Add("receipt", "order_rcptid_11");
        //        options.Add("currency", "INR");
        //        options.Add("payment_capture", 1);
        //        Order order = client.Order.Create(options);
        //        donation.payment_gateway_orderid = order["id"].ToString();

        //        _unitofWork.donation.Add(donation);
        //        _unitofWork.Save();
        //        return new JsonResult(new { status = true, donation = donation });
        //        //return RedirectToPage("/Payment", new { orderId=donation.payment_gateway_orderid });
        //    }
        //    return new JsonResult(new { status = false });
        //    //return Page();
        //}


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
        private IEnumerable<SelectListItem> getProfessionList()
        {
            var list = _unitofWork.profession.GetAll(u=>u.IsActive==true,orderby: u => u.OrderBy(m => m.Order)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
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
