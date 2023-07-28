using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class VideoModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public IEnumerable<galleryCategory> categories { get; set; }
        public IEnumerable<gallery> galleries { get; set; }
        public int pageSize = 10;
        public VideoModel(IUnitOfWork unitofWork)
        {
            _unitOfWork=unitofWork;
        }
        public void OnGet()
        {
            categories = _unitOfWork.galleryCategory.GetAll(orderby: u => u.OrderBy(m => m.Order));
            galleries=_unitOfWork.gallery.GetAll(u => u.filetypeId==2, pageNumber: 1, pageSize: pageSize);
        }
    }
}
