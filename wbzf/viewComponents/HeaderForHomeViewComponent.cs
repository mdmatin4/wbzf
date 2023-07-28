using Microsoft.AspNetCore.Mvc;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.viewComponents
{
    public class HeaderForHomeViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public HeaderForHomeViewComponent(IUnitOfWork unitOfWork)
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
