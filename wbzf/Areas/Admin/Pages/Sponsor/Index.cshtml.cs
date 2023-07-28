
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Sponsor
{

    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<wbzf.Model.Sponsor> sponsors { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var newslinkfromdb = _unitOfWork.newsLink.GetFirstOrDefault(u => u.Id==id);
            if (newslinkfromdb == null)
            {
                return NotFound();

            }
            _unitOfWork.newsLink.Remove(newslinkfromdb);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {

            sponsors = _unitOfWork.sponsor.GetAll(orderby: u => u.OrderBy(c => c.displayOrder));
        }
    }
}
