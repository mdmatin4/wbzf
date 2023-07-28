using Microsoft.AspNetCore.Mvc;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class galleryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public galleryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { success = true, data = _unitOfWork.profession.GetAll(u => u.IsActive==true, orderby: u => u.OrderBy(m => m.Order)) });
        }

        [HttpGet]
        [Route("{fileType:int}/{pageNumber:int}/{pageSize:int}")]
        public IActionResult Get(int pageNumber,int fileType,int pageSize)
        {
            var images = _unitOfWork.gallery.GetAll(u => u.filetypeId==fileType, pageNumber: pageNumber, pageSize: pageSize); // Fetching 5 images per page
            return Json(images);
        }
    }
}
