using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Contact
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<contactform> contactforms { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var contactformfromdb = _unitOfWork.contactForm.GetFirstOrDefault(u => u.Id==id);
            if (contactformfromdb == null)
            {
                return NotFound();

            }
            _unitOfWork.contactForm.Remove(contactformfromdb);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {
            contactforms = _unitOfWork.contactForm.GetAll(orderby: u => u.OrderByDescending(c => c.Created_at));
        }
    }
}
