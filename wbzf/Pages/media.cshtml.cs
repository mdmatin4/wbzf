using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class mediaModel : PageModel
    {
        private IUnitOfWork _unitOfWork;
        public IEnumerable<newslink> newslinks { get; set; }
        public int pageSize = 10;
        public mediaModel(IUnitOfWork unitofWork)
        {
            _unitOfWork=unitofWork;
        }
        public void OnGet()
        {
            newslinks=_unitOfWork.newsLink.GetAll(orderby: u => u.OrderBy(m => m.displayOrder),pageNumber: 1, pageSize: pageSize);
        }

    }
}
