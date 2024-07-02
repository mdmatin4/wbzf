using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Model.ViewModel;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class CommonApplicationFormModel : PageModel
    {


        private IUnitOfWork _unitOfWork;

        public string company_terms;
        //  public InputRegisterModel InputModel { get; set; }
        [BindProperty]
        public CommonUserRgistration InputModel { get; set; }


        public ApplicationRegister appreg { get; set; }

        public ApplicationUser user { get; set; }
        public Scheme scheme { get; set; }
        public Company company { get; set; }
        //public donation Donation { get; set; }
        public IEnumerable<SelectListItem> professionlist { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CommonApplicationFormModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser>
            userManager, IUserStore<ApplicationUser> userStore, SignInManager<ApplicationUser> signInManager,
            ILogger<ApplicationUser> logger,
            Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            appreg = new();
        }

        public void OnGet(int scheme_id)
        {

            company_terms = _unitOfWork.company.GetCompany().terms_for_coaching;
            professionlist = getprofessionlist();
            scheme = _unitOfWork.scheme.GetFirstOrDefault(u => u.Id == scheme_id, includeProperties: "Purpose");

        }
        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            returnUrl ??= Url.Content("~/Admin/Dashboard");

            ModelState.Remove("InputModel.Mother_Name");
            ModelState.Remove("InputModel.guardianName");
            ModelState.Remove("InputModel.Father_name");
            ModelState.Remove("InputModel.familyIncome");
            ModelState.Remove("InputModel.parentType");
            ModelState.Remove("InputModel.UserName");

            if (ModelState.IsValid)
            {

                // user create
                var user = CreateUser();
                user.Full_Name = InputModel.Full_Name;
                user.parentType = Request.Form["radioInline"].ToString();

                user.FatherName = InputModel.FatherName;
                user.fatherIncome = InputModel.fatherIncome;
                user.FatherOccupation_ID = InputModel.fatherOccupationId;

                user.Mother_Name = InputModel.Mother_Name;
                user.motherIncome = InputModel.motherIncome;
                user.MotherOccupation_ID = InputModel.motherOccupationId;

                user.guardianName = InputModel.guardianName;
                user.relation_with_guardian = InputModel.relation_with_guardian;
                user.guardianIncome = InputModel.guardianIncome;
                user.GuardianOccupation_ID = InputModel.guardianOccupationId;


                user.DateofBirth = InputModel.DateofBirth;
                user.Gender = InputModel.Gender;
                user.ProfessionId = InputModel.ProfessionId;
                user.CastCategory = InputModel.category;
                user.adhaar_no = InputModel.adhaarno;
                user.PhoneNumber = InputModel.PhoneNumber;
                user.Email = InputModel.Email;

                user.Vill = InputModel.Vill;
                user.PostOffice = InputModel.PostOffice;
                user.PoliceStation = InputModel.PoliceStation;
                user.District = InputModel.District;
                user.State = InputModel.State;
                user.PIN = InputModel.PIN;

                user.bankName = InputModel.bankName;
                user.bankBranchName = InputModel.bankBranchName;
                user.bankAcNo = InputModel.bankAcNo;
                user.bankIFSC = InputModel.bankIFSC;

                user.created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                await _userStore.SetUserNameAsync(user, InputModel.PhoneNumber, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, InputModel.Password);
                if (result.Succeeded)
                {
                    if (InputModel.Email != null)
                    {
                        try
                        {
                            //    await _emailStore.SetEmailAsync(user, InputModel.Email, CancellationToken.None);
                            //    await _emailSender.SendEmailAsync(InputModel.Email, $"Donation Registration Successful : {InputModel.Full_Name}",
                            //    $"Your registration has been successfully completed . Please login with you Mobile no: {InputModel.PhoneNumber} as username and {InputModel.Password} as Password to login..");
                            string body = "<p>Hello <strong>" + InputModel.Full_Name + "</strong>,&nbsp;<br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; You application for is submitted to us. We will review the form and contact you soon.Please login with you Mobile no: " + InputModel.PhoneNumber + " as username and " + InputModel.Password + " as Password.&nbsp;<br><br>Thanking You,&nbsp;<br>" + _unitOfWork.company.GetCompany().name + "</p>";
                            await _emailSender.SendEmailAsync(InputModel.Email, "Applied Successfully",
                               $"{body}");

                        }
                        catch (Exception ex) { }


                    }
                    await _userManager.AddToRoleAsync(user, SD.Beneficiary);

                    //Application Registration

                    appreg.Full_Name = InputModel.Full_Name;
                    appreg.parentType = Request.Form["radioInline"].ToString();

                    appreg.Father_name = InputModel.FatherName;
                    appreg.fatherIncome = InputModel.fatherIncome;
                    appreg.father_OccupationId = InputModel.fatherOccupationId;

                    appreg.Mother_name = InputModel.Mother_Name;
                    appreg.motherIncome = InputModel.motherIncome;
                    appreg.mother_OccupationId = InputModel.motherOccupationId;

                    appreg.guardianName = InputModel.guardianName;
                    appreg.relation_with_guardian = InputModel.relation_with_guardian;
                    appreg.guardianIncome = InputModel.guardianIncome;
                    appreg.guardian_OccupationId = InputModel.guardianOccupationId;

                    appreg.DateofBirth = InputModel.DateofBirth;
                    appreg.Gender = InputModel.Gender;
                    appreg.ProfessionId = InputModel.ProfessionId;
                    appreg.category = InputModel.category;
                    appreg.adhaarno = InputModel.adhaarno;
                    appreg.PhoneNumber = InputModel.PhoneNumber;
                    appreg.Email = InputModel.Email;

                    appreg.Vill = InputModel.Vill;
                    appreg.PostOffice = InputModel.PostOffice;
                    appreg.PoliceStation = InputModel.PoliceStation;
                    appreg.District = InputModel.District;
                    appreg.State = InputModel.State;
                    appreg.PIN = InputModel.PIN;

                    appreg.bankName = InputModel.bankName;
                    appreg.bankBranchName = InputModel.bankBranchName;
                    appreg.bankAcNo = InputModel.bankAcNo;
                    appreg.bankIFSC = InputModel.bankIFSC;

                    appreg.SchemeId = InputModel.SchemeId;
                    appreg.PurposeId = InputModel.PurposeId;
                    appreg.application_Status = SD.Draft;
                    appreg.Is_Past_Scholar = false;

                    appreg.ApplicationUserId = user.Id;
                    appreg.created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    _unitOfWork.applicationRegister.Add(appreg);
                    _unitOfWork.Save();

                    TempData["success"] = "Your  registration has been successfully completed. Please complete your Application Form";
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
            company = _unitOfWork.company.GetCompany();
            professionlist = _unitOfWork.profession.getProfessionforSelectItem();
            return Page();
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    InputModel.Regitration_Number = "tempno";
        //    _unitOfWork.InputModel.Add(InputModel);
        //    _unitOfWork.Save();
        //    InputModel.Regitration_Number = Formula.MakeApplicationIdForExam(_unitOfWork.company.GetCompany().company_short_name, "SCHL", InputModel.Mother_Name.ToString());
        //    _unitOfWork.InputModel.update(InputModel);
        //    _unitOfWork.Save();
        //    if (InputModel.Email != null)
        //    {
        //        try
        //        {


        //            string body = "<p>Hello <strong>" + InputModel.Full_Name + "</strong>,&nbsp;<br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; You application for is submitted to us. Your Application no is: " + InputModel.Regitration_Number + " We will review the form and contact you soon.&nbsp;<br><br>Thanking You,&nbsp;<br>" + _unitOfWork.company.GetCompany().name + "</p>";
        //            await _emailSender.SendEmailAsync(InputModel.Email, "Applied Successfully",
        //               $"{body}");

        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return RedirectToPage("./ScholarshipApplicationSuccess", new { id = scholarshipApplication.Id });

        //}
        private IEnumerable<SelectListItem> getprofessionlist()
        {
            var list = _unitOfWork.profession.GetAll(orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
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
