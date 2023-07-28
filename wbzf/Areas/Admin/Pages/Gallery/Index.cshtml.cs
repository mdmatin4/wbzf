using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Gallery
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<gallery> galleryitems { get; set; }
        private readonly IWebHostEnvironment _hostEnvironment;
        public IndexModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork= unitOfWork;
            _hostEnvironment= hostEnvironment;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            string webRootPath = _hostEnvironment.WebRootPath;

            var galleryfromdb = _unitOfWork.gallery.GetFirstOrDefault(u => u.Id==id);
            if (galleryfromdb == null)
            {
                return NotFound();

            }
            //delete the old image
            if (galleryfromdb.ImageUrl!=null)
            {
                var oldImagePath = Path.Combine(webRootPath, galleryfromdb.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            //delete the old thumnail
            if (galleryfromdb.ThumbnailUrl!=null)
            {
                var oldImagePath = Path.Combine(webRootPath, galleryfromdb.ThumbnailUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            _unitOfWork.gallery.Remove(galleryfromdb);
            _unitOfWork.Save();

            return RedirectToPage();
        }
        public void OnGet()
        {
            galleryitems = _unitOfWork.gallery.GetAll(orderby: u => u.OrderBy(c => c.createdat),includeProperties: "Category");
        }
    }
}
