using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class ReportModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public IEnumerable<Report> Reports { get; set; }
        public ReportModel(IUnitOfWork unitofWork)
        {
            _unitOfWork=unitofWork;
        }
        public void OnGet()
        {
            Reports=_unitOfWork.report.GetAll(orderby: m=>m.OrderBy(m=>m.displayOrder));
        }
    }
}
