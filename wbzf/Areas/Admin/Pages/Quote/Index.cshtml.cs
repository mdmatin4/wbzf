using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Quote
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<quote> quotes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var quote = _unitOfWork.quote.GetFirstOrDefault(u => u.Id==id);
            if (quote == null)
            {
                return NotFound();

            }
            _unitOfWork.quote.Remove(quote);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {
            quotes = _unitOfWork.quote.GetAll();
        }
    }
}
