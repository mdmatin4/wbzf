using Microsoft.AspNetCore.Mvc;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.viewComponents
{
    public class HeaderForHomeViewComponent : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
