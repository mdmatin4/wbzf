using Microsoft.AspNetCore.Mvc;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.viewComponents
{
    public class HeaderForAllPageViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public HeaderForAllPageViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Company = _unitOfWork.company.GetCompany();
            return View(Company);
        }
    }
}
