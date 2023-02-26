using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public string exam_name { get; set; }
        public IEnumerable<coachingForm> coachingForms { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(string exam,string status)
        {
            exam_name=exam; 
            coachingForms=_unitOfWork.coachingApplication.GetAll(u => u.exam_name==exam_name && u.status==status);           
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
           
            var form = _unitOfWork.coachingApplication.GetFirstOrDefault(u => u.Id==id);
            if (form == null)
            {
                return NotFound();

            }
            exam_name=form.exam_name;
            _unitOfWork.coachingApplication.Remove(form);
            _unitOfWork.Save();

            return RedirectToPage("",new {exam=exam_name});
        }
    }
}
