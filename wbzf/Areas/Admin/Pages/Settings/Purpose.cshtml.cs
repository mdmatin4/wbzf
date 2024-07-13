using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Settings
{
    public class PurposeModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        [BindProperty]
        public Purpose purpose { get; set; }
        public IEnumerable<Purpose> PurposeList { get; set; }
        public int purposeID { get; set; }
        public PurposeModel(IUnitOfWork unitOfWork)
        {
            purpose = new()
            {
                IsActive = true,
            };
            _unitofWork = unitOfWork;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                purpose = _unitofWork.purpose.GetFirstOrDefault(u => u.Id == id);
            }
            PurposeList = _unitofWork.purpose.GetAll(u => u.IsActive == true, orderby: u => u.OrderBy(m => m.Order));
        }

        public IActionResult OnPost()
        {
            if (purpose.Id == 0)
            {
                purpose.IsActive = true;
                purpose.Created_at = DateTime.Now;
                purpose.Form_url = Request.Form["rdFormUrl"].ToString();
                _unitofWork.purpose.Add(purpose);
                _unitofWork.Save();
                if (purpose.IsDefault == true)
                {
                    purposeID = purpose.Id;
                    _unitofWork.purpose.updatestatus(purposeID);
                    _unitofWork.Save();
                }

                TempData["success"] = "This Purpose added successfully";

            }
            else
            {
                purpose.Form_url = Request.Form["rdFormUrl"].ToString();
                _unitofWork.purpose.update(purpose);
                purposeID = purpose.Id;
                if (purpose.IsDefault == true)
                {
                    purposeID = purpose.Id;
                    _unitofWork.purpose.updatestatus(purposeID);
                }
                _unitofWork.Save();

                TempData["success"] = "This Purpose updated successfully";
            }

            return RedirectToPage();

        }

        public IActionResult OnPostDelete()
        {
            _unitofWork.purpose.Deactive(purpose);
            _unitofWork.Save();
            TempData["delete"] = "This purpose is deleted.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit(int id)
        {
            return RedirectToPage(new { id = id });
        }
    }
}
