using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using wbzf.DataAccess.Repository;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.AccountManagement
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class AccountStatementModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        public IEnumerable<SelectListItem> AccountList { get; set; }
        public TransactionHistory txnHistory { get; set; }
        public AccountStatementModel(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
       

        public void OnGet()
        {
            AccountList = getAccountlist();

        }
        private IEnumerable<SelectListItem> getAccountlist()
        {
            var list = _unitofWork.account.GetAll(u => u.is_deleted == false && u.isvisibletoPublic == true, orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name + " (Account No: " + i.Account_no + " )",
                Value = i.Id.ToString()
            });
            return list;
        }
        public async Task<IActionResult> OnPostSubmit(string txnId)
        {
            return ViewComponent("TxnHist", new { _unitofWork, txnHistId = txnId });

        }
        public IActionResult OnPostTablePopup(int pageIndex = 1, int pageSize = 10, string? sortColumn = null, string? sortDirection = null, string searchTerm = "",  DateTime? fromDate = null, DateTime? toDate = null, int? accountId = null)
        {
            // Invoke component
            var component = ViewComponent("AccountStatement", new { _unitofWork, pageIndex, pageSize, sortColumn, sortDirection, searchTerm, fromDate, toDate, accountId });
            return component;

        }

    }
}
