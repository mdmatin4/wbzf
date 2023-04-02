using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Schemes
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Scheme scheme { get; set; }
        public IEnumerable<SelectListItem> purposes { get; set; }


        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            scheme = new ();
        }
        public void OnGet(int? id)
        {
            purposes=_unitOfWork.purpose.GetAll(u => u.IsActive==true, orderby: u => u.OrderBy(m => m.Order)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = i.IsDefault
            });
            if (id!=null)
            {
                scheme=_unitOfWork.scheme.GetFirstOrDefault(u => u.Id==id);
               
            }

        }
       
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (scheme.Id==0)
                {
                    scheme.IsActive=true;
                    scheme.Created_at=DateTime.Now;
                    _unitOfWork.scheme.Add(scheme);
                    _unitOfWork.Save();
                    TempData["success"] = "Scheme created successfully";
                }
                else
                {
                    _unitOfWork.scheme.update(scheme);
                    _unitOfWork.Save();
                    TempData["success"] = "Scheme Updated successfully";
                }
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
