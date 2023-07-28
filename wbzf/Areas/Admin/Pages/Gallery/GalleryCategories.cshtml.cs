using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Gallery
{
    public class GalleryCategoriesModel : PageModel
    {
        [BindProperty]
        public galleryCategory category { get; set; }
        public IEnumerable<galleryCategory> categories { get; set; }
       
        private IUnitOfWork _unitOfWork;

        public GalleryCategoriesModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                category=_unitOfWork.galleryCategory.GetFirstOrDefault(u=>u.Id == id.Value);
            }
            categories=_unitOfWork.galleryCategory.GetAll(orderby: u => u.OrderBy(m => m.CreatedDate));
            
        }
        public async Task<IActionResult> OnPostEditCategory(int id)
        {
            return RedirectToPage(new { id=id });
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
           var  cat=_unitOfWork.galleryCategory.GetFirstOrDefault(u => u.Id==id);
            _unitOfWork.galleryCategory.Remove(cat);
            _unitOfWork.Save(); 
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSave()
        {
            if (category.Id!=0)
            {
                _unitOfWork.galleryCategory.update(category);
                _unitOfWork.Save();
            }
            else
            {
                category.CreatedDate = DateTime.Now;
                _unitOfWork.galleryCategory.Add(category);
                _unitOfWork.Save();
            }
            return RedirectToPage();
        }
    }
}
