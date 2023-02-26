using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class PaymentModel : PageModel
    {
        private ApplicationDbContext _db;
        private IUnitOfWork _unitofWork;

        public donation donation { get; set; }
        public Company company { get; set; }
        public PaymentModel(ApplicationDbContext db, IUnitOfWork unitOfWork)
        {
            _db=db;
            _unitofWork=unitOfWork;
        }
        public void OnGet(string orderId)
        {
            company=_unitofWork.company.GetCompany();
            donation=_unitofWork.donation.GetFirstOrDefault(u => u.payment_gateway_orderid==orderId);
        }
    }
}
