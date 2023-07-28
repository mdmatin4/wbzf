using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Quote
{
    [Authorize(Roles = $"{SD.Admin}")]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public quote quote { get; set; }


        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            quote = new ();
        }
        public void OnGet(int? id)
        {
            if (id!=null)
            {
                quote=_unitOfWork.quote.GetFirstOrDefault(u => u.Id==id);
            }

        }

        public async Task<IActionResult> OnPost()
        {
            
            if (ModelState.IsValid)
            {
                if (quote.Id==0)
                {
                    _unitOfWork.quote.Add(quote);
                    _unitOfWork.Save();
                    TempData["success"] = "Category created successfully";
                }
                else
                {
                    _unitOfWork.quote.update(quote);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Updated successfully";
                }
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
