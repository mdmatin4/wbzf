using Microsoft.AspNetCore.Mvc;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public newsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("{pageNumber:int}/{pageSize:int}")]
        public IActionResult Get(int pageNumber, int pageSize)
        {
            var result = _unitOfWork.newsLink.GetAll( pageNumber: pageNumber, pageSize: pageSize,orderby: u=>u.OrderBy(m=>m.displayOrder)); 
            return Json(result);
        }
    }
}
