using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var scheme = _unitOfWork.scheme.GetFirstOrDefault(u => u.Id==id);
            if (scheme == null)
            {
                return NotFound();

            }

            _unitOfWork.scheme.Deactive(scheme);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {
            Schemes = _unitOfWork.scheme.GetAll(includeProperties: "Purpose", orderby: u => u.OrderByDescending(c => c.Created_at));
        }
    }

}
