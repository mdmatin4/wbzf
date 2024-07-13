using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;
using static System.Net.Mime.MediaTypeNames;

namespace wbzf.Areas.Admin.Pages.Applications
{
    [Authorize(Roles = $"{SD.Admin},{SD.ScrutinyOfficer},{SD.Manager},{SD.FinanceOfficer}")]

    public class ApplicationListModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        [BindProperty]
        public IEnumerable<ApplicationRegister> applicationList { get; set; }
        public Purpose purpose { get; set; }
        public IEnumerable<SelectListItem> schemelist { get; set; }
         public IEnumerable<SelectListItem> statuslist { get; set; }

        public ApplicationListModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public void OnGet(int purposeId)

        {
            //applicationList= _unitOfWork.applicationRegister.GetAll(u => u.Id == id && u.application_Status!=SD.Draft && u.application_Status != SD.Complete, includeProperties:"Scheme,Purpose").DistinctBy(u=>u.SchemeId);
            purpose = _unitOfWork.purpose.GetFirstOrDefault(u => u.Id == purposeId);
            schemelist = getScheme();
            statuslist = getStatus();

        }
        public IActionResult OnPostTablePopup(int pageIndex = 1, int pageSize = 10, string? sortColumn = null, string? sortDirection = null, string searchTerm = "", int? schemeId = null, string? stutus= null,int? purposeId=null)
        {
           
            // Invoke component
            var component = ViewComponent("ApplicationList", new { _unitOfWork, pageIndex, pageSize, sortColumn, sortDirection, searchTerm, schemeId, stutus, purposeId });
            return component;

        }
        private IEnumerable<SelectListItem> getScheme()
        {
            var list = _unitOfWork.scheme.GetAll(orderby: m => m.OrderBy(x => x.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
        }
    private IEnumerable<SelectListItem> getStatus()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text="All",Selected=true });
            list.Add(new SelectListItem(text: SD.Applied, value: SD.Applied));
            list.Add(new SelectListItem(text: SD.Draft, value: SD.Draft));
            list.Add(new SelectListItem(text: SD.Verified, value: SD.Verified));
            list.Add(new SelectListItem(text: SD.Approved, value: SD.Approved));
            return list;
        }
    }
}
