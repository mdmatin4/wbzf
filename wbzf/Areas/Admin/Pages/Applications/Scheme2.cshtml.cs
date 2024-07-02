using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;
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

    public class Scheme2Model : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public ApplicationRegister appReg { get; set; }
        public Scheme scheme { get; set; }
        [BindProperty]
        public ApplicationProcessing appProcess { get; set; }
        [BindProperty]
        public SanctionedApplication SanctionedApplication { get; set; }
        public string purpose { get; set; }
        public IEnumerable<SelectListItem> professionlist { get; set; }
        public bool is_admin { get; set; } = false;
        public bool is_manager { get; set; } = false;
        public bool is_beneficiary { get; set; } = false;
        public bool is_donor { get; set; } = false;
        public bool is_scrutinyOfficer { get; set; } = false;
        public bool is_financeOfficer { get; set; } = false;
        public Scheme2Model(IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment)
        {

            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
            _unitOfWork = unitOfWork;
            appReg = new();
            appProcess = new();
            SanctionedApplication = new();

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
            appReg.Full_Name = user.Full_Name;
            appReg.PhoneNumber = user.PhoneNumber;
            appReg.Email = user.Email;
            appReg.ProfessionId = user.ProfessionId;
            appReg.DateofBirth = user.DateofBirth;
            appReg.category = user.CastCategory;
            appReg.Gender = user.Gender;
            appReg.adhaarno = user.adhaar_no;
            appReg.Photo_url = user.ImageUrl;

            //Address Details From User Table
            appReg.Vill = user.Vill;
            appReg.PostOffice = user.PostOffice;
            appReg.PoliceStation = user.PoliceStation;
            appReg.District = user.District;
            appReg.State = user.State;
            appReg.PIN = user.PIN;

            //Family Details From User Table
            appReg.Father_name = user.FatherName;
            appReg.Mother_name = user.Mother_Name;
            appReg.guardianName = user.guardianName;
            appReg.fatherIncome = user.fatherIncome;
            appReg.motherIncome = user.motherIncome;
            appReg.guardianIncome = user.guardianIncome;
            appReg.father_OccupationId = user.FatherOccupation_ID;
            appReg.mother_OccupationId = user.MotherOccupation_ID;
            appReg.guardian_OccupationId = user.GuardianOccupation_ID;
            appReg.relation_with_guardian = user.relation_with_guardian;
            appReg.parentType = user.parentType;

            //Family Details From User Table
            appReg.bankAcNo = user.bankAcNo;
            appReg.bankName = user.bankName;
            appReg.bankBranchName = user.bankBranchName;
            appReg.bankIFSC = user.bankIFSC;
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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            appReg = _unitOfWork.applicationRegister.GetFirstOrDefault(u => u.Id == id, includeProperties: "Scheme,Purpose");

            if (is_beneficiary)
            {
                await LoadAsync(user);
            }
            else
            {
                appProcess = _unitOfWork.applicationProcessing.GetFirstOrDefault(u => u.Id == id);
            }

            professionlist = getprofessionlist();
            return Page();
        }

        public async Task<IActionResult> OnPostSave()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userid = claim.Value;
            is_beneficiary = User.IsInRole(SD.Beneficiary);
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new;
            var uploads = Path.Combine(webRootPath, @"images\Application_Image");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (files.Count > 0)
            {
                //var extension = Path.GetExtension(item.FileName);
                //fileName_new = Guid.NewGuid().ToString();
                //if (appReg.Photo_url.Length > 0)
                //{
                //    fileName_new = "photo" + fileName_new;
                //    appReg.Photo_url = @"\images\Application_Image\" + fileName_new + extension;
                //}
                foreach (var item in files)
                {
                    var extension = Path.GetExtension(item.FileName);
                    fileName_new = Guid.NewGuid().ToString();

                    if (item.Name == "appReg.Photo_url")
                    {
                        fileName_new = "photo" + fileName_new;
                        appReg.Photo_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.sign_url")
                    {
                        fileName_new = "sign" + fileName_new;
                        appReg.sign_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.adhaarUrl")
                    {
                        fileName_new = "aadhaar" + fileName_new;
                        appReg.adhaarUrl = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.passbookUrl")
                    {
                        fileName_new = "passbook" + fileName_new;
                        appReg.passbookUrl = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.category_url")
                    {
                        fileName_new = "cast" + fileName_new;
                        appReg.category_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.admissionreceipt_url")
                    {
                        fileName_new = "admission" + fileName_new;
                        appReg.admissionreceipt_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.marksheet_url")
                    {
                        fileName_new = "marksheet" + fileName_new;
                        appReg.marksheet_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.incomeproof_url")
                    {
                        fileName_new = "income" + fileName_new;
                        appReg.incomeproof_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.bonafied_certificate_url")
                    {
                        fileName_new = "bonafied" + fileName_new;
                        appReg.bonafied_certificate_url = @"\images\Application_Image\" + fileName_new + extension;
                    }


                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        item.CopyTo(fileStream);
                    }
                }
            }

            if (appReg.Id == null)
            {

                if (is_beneficiary)
                {
                    appReg.parentType = Request.Form["radioInline"].ToString();
                    //appReg.Is_Past_Scholar = Request.Form["radioScholar"].ToString();
                    appReg.ApplicationUserId = userid;
                    appReg.created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    appReg.SchemeId = scheme.Id;
                    appReg.PurposeId = scheme.purposeId;
                    appReg.application_Status = SD.Applied;
                    _unitOfWork.applicationRegister.Add(appReg);
                    _unitOfWork.Save();
                    TempData["success"] = "Your Application has been submitted successfully";
                }
            }
            else
            {
                if (appReg.application_Status == SD.Draft && is_beneficiary)
                {
                    appReg.parentType = Request.Form["radioInline"].ToString();
                    appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    appReg.application_Status = SD.Applied;
                    _unitOfWork.applicationRegister.update(appReg);
                    _unitOfWork.Save();
                    TempData["success"] = "Your Application has been submitted successfully";
                }
                else
                {
                    TempData["warning"] = "You have already submitted Application. You can not modify or update Application.";
                }
            }

            return RedirectToPage("/Dashboard");
        }
        public async Task<IActionResult> OnPostUpdate()
        {
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new;
            var uploads = Path.Combine(webRootPath, @"images\Application_Image");

            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (files.Count > 0)
            {
                foreach (var item in files)
                {
                    var extension = Path.GetExtension(item.FileName);
                    fileName_new = Guid.NewGuid().ToString();

                    if (item.Name == "appReg.Photo_url")
                    {
                        fileName_new = "photo" + fileName_new;
                        appReg.Photo_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.sign_url")
                    {
                        fileName_new = "sign" + fileName_new;
                        appReg.sign_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.adhaarUrl")
                    {
                        fileName_new = "aadhaar" + fileName_new;
                        appReg.adhaarUrl = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.passbookUrl")
                    {
                        fileName_new = "passbook" + fileName_new;
                        appReg.passbookUrl = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.category_url")
                    {
                        fileName_new = "cast" + fileName_new;
                        appReg.category_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.admissionreceipt_url")
                    {
                        fileName_new = "admission" + fileName_new;
                        appReg.admissionreceipt_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.marksheet_url")
                    {
                        fileName_new = "marksheet" + fileName_new;
                        appReg.marksheet_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.incomeproof_url")
                    {
                        fileName_new = "income" + fileName_new;
                        appReg.incomeproof_url = @"\images\Application_Image\" + fileName_new + extension;
                    }
                    else if (item.Name == "appReg.bonafied_certificate_url")
                    {
                        fileName_new = "bonafied" + fileName_new;
                        appReg.bonafied_certificate_url = @"\images\Application_Image\" + fileName_new + extension;
                    }


                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        item.CopyTo(fileStream);
                    }
                }
            }
            if (!is_beneficiary && appReg.application_Status == SD.Applied)
            {
                appReg.parentType = Request.Form["radioInline"].ToString();
                appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                _unitOfWork.applicationRegister.updation(appReg);
                _unitOfWork.Save();
                TempData["success"] = "Application has been updated successfully";
            }
            return RedirectToPage("/Dashashboard");
        }
        public async Task<IActionResult> OnPostVerify()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string ApplicationUserId = claim.Value;
            if (!is_beneficiary && appReg.application_Status == SD.Applied)
            {
                appProcess.VerifierId = ApplicationUserId;
                appProcess.ApplicationId = appReg.Id;
                appProcess.Verify_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                _unitOfWork.applicationProcessing.Add(appProcess);
                appReg.application_Status = SD.Verified;
                appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                _unitOfWork.applicationRegister.Verify(appReg);
                _unitOfWork.Save();
                TempData["success"] = "Application has been Verified successfully";

            }
            else
            {
                TempData["warning"] = "Please Complete this Application";
            }
            return RedirectToPage("/Dashboard");
        }
        public async Task<IActionResult> OnPostSanction()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string ApplicationUserId = claim.Value;
            if (!is_beneficiary && appReg.application_Status == SD.Verified)
            {
                if (appReg.Sanction_Amount == null)
                {
                    TempData["warning"] = "Please Enter Valid Amount.";

                }
                else
                {
                    if (appProcess.VerifierId == ApplicationUserId)
                    {
                        TempData["warning"] = "Aproval authority and Verify authority can not be same Person";
                    }
                    else
                    {
                        appProcess.ApproverId = ApplicationUserId;
                        appProcess.Approved_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                        _unitOfWork.applicationProcessing.Sanction(appProcess);
                        appReg.application_Status = SD.Sanctioned;
                        appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                        _unitOfWork.applicationRegister.Sanction(appReg);

                        // Sanctioned Application Table

                        SanctionedApplication.Created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                        SanctionedApplication.Payment_Status = SD.Sanctioned;
                        SanctionedApplication.ApplicationId = appReg.Id;
                        _unitOfWork.sanctionedApplication.Add(SanctionedApplication);
                        _unitOfWork.Save();
                        TempData["success"] = "Application has been Appoved and Sanctioned successfully. " +
                       "The amount will be credited in the Applicant Bank Account shortly.";
                    }
                }
            }
            else
            {
                TempData["warning"] = "Please Verify for this Application";
            }
            return RedirectToPage("/Dashboard");
        }

    }
}
