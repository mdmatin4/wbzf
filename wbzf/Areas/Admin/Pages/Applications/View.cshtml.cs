using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Applications
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    public class ViewModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public coachingForm coachingForm { get; set; }
        public ViewModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public void OnGet(int id)
        {
            coachingForm=_unitOfWork.coachingApplication.GetFirstOrDefault(x => x.Id == id);

        }
        public IActionResult OnPostReject(int id)
        {
            coachingForm=_unitOfWork.coachingApplication.GetFirstOrDefault(x => x.Id == id);
            coachingForm.status=SD.Rejected;
            _unitOfWork.coachingApplication.UpdateStatus(coachingForm);
            _unitOfWork.Save();
            return Page();
        }
        public IActionResult OnPostApprove(int id)
        {
            coachingForm=_unitOfWork.coachingApplication.GetFirstOrDefault(x => x.Id == id);
            coachingForm.status=SD.Approved;
            _unitOfWork.coachingApplication.UpdateStatus(coachingForm);
            _unitOfWork.Save();
            return Page();
        }
        public IActionResult OnPostReview(int id)
        {
            coachingForm=_unitOfWork.coachingApplication.GetFirstOrDefault(x => x.Id == id);
            coachingForm.status=SD.InProgress;
            _unitOfWork.coachingApplication.UpdateStatus(coachingForm);
            _unitOfWork.Save();
            return Page();
        }
    }
}
