using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.AccountManagement
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class AccountTransferModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public IEnumerable<SelectListItem> userList { get; set; }
        [BindProperty]
        public MainAc MainAc { get; set; }
        [BindProperty]
        public TransactionHistory Transactions { get; set; }
        public IEnumerable<SelectListItem> AccountList { get; set; }
        public AccountTransferModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitofWork = unitOfWork;
            _userManager = userManager;
            MainAc = new();
            Transactions = new();
        }
        private IEnumerable<SelectListItem> getAccountlist()
        {
            var list = _unitofWork.account.GetAll(u => u.is_deleted == false, orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name + " (Account No: " + i.Account_no + " )",
                Value = i.Id.ToString()
            });
            return list;
        }
        private async Task<IEnumerable<SelectListItem>> GetUserAsync()
        {
            var userList = await (from user in _userManager.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      FullName = user.Full_Name,
                                      user.Email,
                                      user.EmailConfirmed,
                                      user.bankAcNo,

                                  }).ToListAsync();
            var list = userList.Select(i => new SelectListItem()
            {
                Text = i.FullName + " (Account No: " + i.bankAcNo + " )",
                Value = i.UserId.ToString()
            });

            return list;
        }

        public void OnGet()
        {
            AccountList = getAccountlist();
            userList = GetUserAsync().Result;
        }
      
        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string ApplicationUserId = claim.Value;

            if (Transactions.Account_Id != Transactions.ToAccount_Id)
            {
                double balance = _unitofWork.mainAccount.GetFirstOrDefault(a => a.Account_Id == Transactions.Account_Id, orderby: m => m.OrderByDescending(c => c.Created_at)).Bal;
                if (Transactions.Amount > balance)
                {
                    TempData["warning"] = "Transaction can not be proceed due to Insufficient Balance.";
                }
                else
                {
                    Transactions.Transaction_Purpose = SD.Account_Transfer;
                    Transactions.PayBy_Id = ApplicationUserId;
                    Transactions.Created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    Transactions.Payment_Status = SD.Success;
                    _unitofWork.transactionHistory.Add(Transactions);
                    _unitofWork.Save();
                    _unitofWork.mainAccount.updateBalance(SD.Substract, Transactions.Id);
                    _unitofWork.Save();

                    TempData["success"] = "Account Transfer has been Successfull.";
                }
            }
            else { TempData["warning"] = "From Account and To Account can not be same."; }
            return RedirectToPage();
        }


    }


}
