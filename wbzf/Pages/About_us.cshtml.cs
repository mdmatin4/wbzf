using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class About_usModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public Company company;

        public About_usModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void OnGet()
        {
            company=_unitOfWork.company.GetCompany();
        }
    }
}
