using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Settings
{
    public class PaymentGatewayModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        [BindProperty]
        public PaymentGateway paymentGateway { get; set; }
        public IEnumerable<PaymentGateway> PaymentGatewayList { get; set; }
        public PaymentGatewayModel(IUnitOfWork unitOfWork)
        {
            paymentGateway=new();
            
            _unitofWork=unitOfWork;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                paymentGateway = _unitofWork.paymentGateway.GetFirstOrDefault(u => u.Id == id);
            }
            PaymentGatewayList= _unitofWork.paymentGateway.GetAll(u=>u.is_deleted==false,orderby: u => u.OrderBy(m => m.created_at));
        }

        public IActionResult OnPost()
        {
            if (paymentGateway.Id==0)
            {
                paymentGateway.created_at = DateTime.Now;
           
                paymentGateway.is_deleted = false;
                _unitofWork.paymentGateway.Add(paymentGateway);
                _unitofWork.Save();
                TempData["success"] = "This Payment Gateway added successfully";

            }
            else
            {
                _unitofWork.paymentGateway.update(paymentGateway);
                _unitofWork.Save();
                TempData["success"] = "This Payment Gateway updated successfully";
            }

            return RedirectToPage();

        }

        public IActionResult OnPostDelete(int id)
        {
            _unitofWork.paymentGateway.SoftDelete(paymentGateway);
            _unitofWork.Save();
            TempData["delete"] = "This Payment Gateway is deleted.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit(int id)
        {
            return RedirectToPage(new { id = id });
        }
    }
}
