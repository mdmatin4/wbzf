
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Report
{

    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<wbzf.Model.Report> reports { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var reportfromDb = _unitOfWork.report.GetFirstOrDefault(u => u.Id==id);
            if (reportfromDb == null)
            {
                return NotFound();

            }
            _unitOfWork.report.Remove(reportfromDb);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {

            reports = _unitOfWork.report.GetAll(orderby: u => u.OrderBy(c => c.displayOrder));
        }
    }
}
