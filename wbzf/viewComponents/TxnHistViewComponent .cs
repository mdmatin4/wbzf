using wbzf.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wbzf.viewComponents
{
    public class TxnHistViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IUnitOfWork _unitOfWork, string txnHistId)
        {
            var txnHistory = _unitOfWork.transactionHistory.GetFirstOrDefault(u => u.Id == txnHistId, includeProperties: "Accounts,ToAccounts,PayBy,PayTo");
           
            return View(txnHistory);
        }
    }
}
