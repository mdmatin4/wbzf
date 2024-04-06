using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Schemes
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Scheme> Schemes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

     
        public void OnGet()
        {
           // Schemes = _unitOfWork.scheme.GetAll(includeProperties: "Purpose", orderby: u => u.OrderByDescending(c => c.Created_at));
        }

        public IActionResult OnPostTablePopup(int pageIndex = 1, int pageSize = 10, string? sortColumn = null, string? sortDirection = null, string searchTerm = "")
        {

            // Invoke component
            var component = ViewComponent("SchemeList", new { _unitOfWork, pageIndex, pageSize, sortColumn, sortDirection, searchTerm });
            return component;

        }

        public async Task<IActionResult> OnPostBan(int id)
        {
            _unitOfWork.scheme.Deactive(id);
            _unitOfWork.Save();
            TempData["success"] = "This Scheme has been deleted successfully";
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostUnban(int id)
        {
            _unitOfWork.scheme.Activate(id);
            _unitOfWork.Save();
            TempData["success"] = "This Scheme has been revibed successfully";
            return RedirectToPage();
        }



    }

}
