using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class professionController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public professionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { success = true, data = _unitOfWork.profession.GetAll(u=>u.IsActive==true, orderby: u=>u.OrderBy(m=>m.Order))});
        }
        [HttpGet]
        [Route("{value:int}")]
        public IActionResult Get(int value)
        {
            return Json(new { success = true, data = new { name= "onek boro"} });
        }

        [HttpPost]
        public  Task<IActionResult> Post([FromQuery]string Name)
        {
            _unitOfWork.profession.Add(new Model.Profession
            {
                Name = Name,
                IsActive = true,
                Created_at = DateTime.Now
            });
            _unitOfWork.Save();
            return null;
        }



    }
}
