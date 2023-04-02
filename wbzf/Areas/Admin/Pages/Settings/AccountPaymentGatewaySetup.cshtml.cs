using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Settings
{
    public class AccountPaymentGatewaySetupModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        [BindProperty]
        public AccountGatewaySetup accountGatewaySetup { get; set; }
        public IEnumerable<AccountGatewaySetup> accountGatewayList { get; set; }
        public IEnumerable<SelectListItem> accountList { get; set; }
        public IEnumerable<SelectListItem> paymentGatewayList { get; set; }
        public AccountPaymentGatewaySetupModel(IUnitOfWork unitOfWork)
        {
            accountGatewaySetup=new();
            
            _unitofWork=unitOfWork;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                accountGatewaySetup = _unitofWork.accountGatewaySetup.GetFirstOrDefault(u => u.Id == id);
            }
            accountList= _unitofWork.account.GetAll(u => u.is_deleted==false && u.isvisibletoPublic==true, orderby: u => u.OrderBy(m => m.created_at)).Select(u=>
                new SelectListItem()
                {
                    Text=u.Name + " (Account No: " + u.Account_no +" )",
                    Value=u.Id.ToString()
                });
            paymentGatewayList= _unitofWork.paymentGateway.GetAll(u => u.is_deleted==false, orderby: u => u.OrderBy(m => m.created_at)).Select(u=>
            new SelectListItem()
            {
                Text=u.Name,
                Value=u.Id.ToString()
            });
            accountGatewayList= _unitofWork.accountGatewaySetup.GetAll(orderby: u => u.OrderBy(m => m.PaymentGatewayId),includeProperties: "Account,PaymentGateway");
        }

        public IActionResult OnPost()
        {
            if (accountGatewaySetup.Id==0)
            {
                accountGatewaySetup.created_at = DateTime.Now;
                _unitofWork.accountGatewaySetup.Add(accountGatewaySetup);
                _unitofWork.Save();
                TempData["success"] = "This Account's Payment Gateway setup is added successfully";

            }
            else
            {
                _unitofWork.accountGatewaySetup.update(accountGatewaySetup);
                _unitofWork.Save();
                TempData["success"] = "Account's Payment Gateway setup is updated successfully";
            }

            return RedirectToPage();

        }

        public IActionResult OnPostDelete(int id)
        {
            _unitofWork.accountGatewaySetup.Remove(accountGatewaySetup);
            _unitofWork.Save();
            TempData["delete"] = "This Account's Payment Gateway setup is deleted.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit(int id)
        {
            return RedirectToPage(new { id = id });
        }
    }
}
