using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Settings
{
    public class AccountModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        [BindProperty]
        public Account account { get; set; }
        public IEnumerable<Account> AccountList { get; set; }
        public AccountModel(IUnitOfWork unitOfWork)
        {
            account=new();
            
            _unitofWork=unitOfWork;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                account = _unitofWork.account.GetFirstOrDefault(u => u.Id == id);
            }
            AccountList= _unitofWork.account.GetAll(u=>u.is_deleted==false,orderby: u => u.OrderBy(m => m.created_at));
        }

        public IActionResult OnPost()
        {
            if (account.Id==0)
            {
                account.created_at = DateTime.Now;
           
                account.is_deleted = false;
                _unitofWork.account.Add(account);
                _unitofWork.Save();
                TempData["success"] = "This Account is added successfully";

            }
            else
            {
                _unitofWork.account.update(account);
                _unitofWork.Save();
                TempData["success"] = "This Account is updated successfully";
            }

            return RedirectToPage();

        }

        public IActionResult OnPostDelete(int id)
        {
            _unitofWork.account.SoftDelete(account);
            _unitofWork.Save();
            TempData["delete"] = "This Account is deleted.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit(int id)
        {
            return RedirectToPage(new { id = id });
        }
    }
}
