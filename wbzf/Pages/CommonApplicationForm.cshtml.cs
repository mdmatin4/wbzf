using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class CommonApplicationFormModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public string company_terms;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        public ScholarshipApplication scholarshipApplication { get; set; }
        public CommonApplicationFormModel(IUnitOfWork unitOfWork, Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender)
        {
            _unitOfWork=unitOfWork;
            _emailSender=emailSender;
            scholarshipApplication = new ScholarshipApplication();
        }
        public void OnGet(string? exam)
        {
            company_terms=_unitOfWork.company.GetCompany().terms_for_coaching;

        }
        public async Task<IActionResult> OnPost()
        {
            scholarshipApplication.application_no="tempno";
            _unitOfWork.scholarshipApplication.Add(scholarshipApplication);
            _unitOfWork.Save();
            scholarshipApplication.application_no=Formula.MakeApplicationIdForExam(_unitOfWork.company.GetCompany().company_short_name, "SCHL", scholarshipApplication.Id.ToString());
            _unitOfWork.scholarshipApplication.update(scholarshipApplication);
            _unitOfWork.Save();
            if (scholarshipApplication.Email!=null)
            {
                try
                {


                    string body = "<p>Hello <strong>"+scholarshipApplication.Name   +"</strong>,&nbsp;<br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; You application for is submitted to us. Your Application no is: "+ scholarshipApplication.application_no +" We will review the form and contact you soon.&nbsp;<br><br>Thanking You,&nbsp;<br>"+ _unitOfWork.company.GetCompany().name +"</p>";
                    await _emailSender.SendEmailAsync(scholarshipApplication.Email, "Applied Successfully",
                       $"{body}");

                }
                catch (Exception ex)
                {

                }
            }

            return RedirectToPage("./ScholarshipApplicationSuccess", new { id = scholarshipApplication.Id });

        }
    }
}
