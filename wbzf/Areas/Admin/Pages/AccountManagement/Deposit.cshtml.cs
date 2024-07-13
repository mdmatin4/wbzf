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
    public class DepositModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        public MainAc MainAcTxn { get; set; }
        [BindProperty]
        public TransactionHistory Transactions { get; set; }
        public IEnumerable<SelectListItem> AccountList { get; set; }
        public DepositModel(IUnitOfWork unitOfWork)
        {
            MainAcTxn = new();
            Transactions = new();
            _unitofWork = unitOfWork;
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

        public void OnGet()
        {
            AccountList = getAccountlist();

        }

        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string ApplicationUserId = claim.Value;
            Transactions.transaction_fees = Transactions.transaction_fees ?? 0;

            Transactions.received_amount = Transactions.Amount - Transactions.transaction_fees.Value;
            Transactions.Transaction_Purpose = SD.Deposite;
            Transactions.PayBy_Id = ApplicationUserId;
            Transactions.Created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            Transactions.Payment_Status = SD.Success;
            _unitofWork.transactionHistory.Add(Transactions);
            _unitofWork.Save();

            _unitofWork.mainAccount.updateBalance(SD.Add, Transactions.Id);
            _unitofWork.Save();
            TempData["success"] = "Amount has been Deposited to the Accont Successfully.";
            return RedirectToPage();
        }


    }
}
