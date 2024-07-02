using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class CommonRegitrationFormModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public Scheme scheme { get; set; }
        public CommonRegitrationFormModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void OnGet(int scheme_id)
        {
            scheme = _unitOfWork.scheme.GetFirstOrDefault(u => u.Id == scheme_id);
            
        }
       
    }
}
