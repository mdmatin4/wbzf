using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Model.ViewModel;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class coachingFormModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public string company_terms;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        public coachingForm coachingForm { get; set; }
        public List<AcademicQualification> academicQualifications { get; set; }
        public coachingFormModel(IUnitOfWork unitOfWork,Microsoft.AspNetCore.Identity.UI.Services.IEmailSender emailSender)
        {
            _unitOfWork=unitOfWork;
            _emailSender=emailSender;
            coachingForm = new coachingForm();
        }
        public void OnGet(string? exam)
        {
            company_terms=_unitOfWork.company.GetCompany().terms_for_coaching;
            if (exam!=null)
            {
                coachingForm.exam_name=exam;
            }
        }
        public async Task<IActionResult> OnPost(coachingForm coachingForm)
        {
            coachingForm.application_no="tempno";
            coachingForm.status=SD.Applied;
            _unitOfWork.coachingApplication.Add(coachingForm);
            _unitOfWork.Save();
            coachingForm.application_no=Formula.MakeApplicationIdForExam(_unitOfWork.company.GetCompany().company_short_name,coachingForm.exam_name,coachingForm.Id.ToString());
            _unitOfWork.coachingApplication.update(coachingForm);
            _unitOfWork.Save();
            if (coachingForm.Email!=null)
            {
                try
                {


                    string body = "<p>Hello <strong>"+coachingForm.Name   +"</strong>,&nbsp;<br>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; You application for is submitted to us. Your Application no is: "+ coachingForm.application_no +" We will review the form and contact you soon.&nbsp;<br><br>Thanking You,&nbsp;<br>"+ _unitOfWork.company.GetCompany().name +"</p>";
                    await _emailSender.SendEmailAsync(coachingForm.Email, "Applied Successfully",
                       $"{body}");
                    
                }
                catch (Exception ex)
                {

                }
            }

            return RedirectToPage("./ApplicationSuccess", new { id = coachingForm.Id });
            
        }
    }
}
