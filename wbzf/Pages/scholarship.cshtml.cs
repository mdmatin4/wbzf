using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class scholarshipModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public scholarshipModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void OnGet(string? exam)
        {
            
            
        }
       
    }
}
