using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class NewsDetailsModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public newslink news { get; set; }
        public Company company { get; set; }
        public int pageSize = 10;
        public NewsDetailsModel(IUnitOfWork unitofWork)
        {
            _unitOfWork=unitofWork;
        }
        public void OnGet(int id)
        {
            news=_unitOfWork.newsLink.GetFirstOrDefault(u=>u.Id==id);
            company=_unitOfWork.company.GetCompany();
        }
    }
}
