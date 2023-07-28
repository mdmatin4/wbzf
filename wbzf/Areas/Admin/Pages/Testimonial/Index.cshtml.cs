using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Testimonial
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<testimonial> testimonials { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var testimonialfromdb = _unitOfWork.testimonial.GetFirstOrDefault(u => u.Id==id);
            if (testimonialfromdb == null)
            {
                return NotFound();

            }
            _unitOfWork.testimonial.Remove(testimonialfromdb);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {
            testimonials = _unitOfWork.testimonial.GetAll(orderby: u=>u.OrderBy(m=>m.DisplayOrder));
        }
    }
}
