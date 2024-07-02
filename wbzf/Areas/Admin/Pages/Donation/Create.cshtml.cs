using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using wbzf.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace wbzf.Areas.Admin.Pages.Donation
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public donation donation { get; set; }
        private readonly IUnitOfWork _unitOfWork;
      
        public IEnumerable<SelectListItem> userList { get; set; }
        public IEnumerable<SelectListItem> AccountList { get; set; }
        public IEnumerable<SelectListItem> purposeList { get; set; }
        public CreateModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            donation = new ();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            AccountList= getAccountlist();
            userList = GetUserAsync().Result;
            purposeList = getPurposelist();
            return Page();
        }
        public JsonResult OnGetAccountNumber(int id)
        {
            var account = _unitOfWork.account.GetFirstOrDefault(a => a.Id == id);
            if (account != null)
            {
                return new JsonResult(account);
            }
            return new JsonResult(null);
        }
        private IEnumerable<SelectListItem> getAccountlist()
        {
            var list = _unitOfWork.account.GetAll(u => u.is_deleted == false, orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
        }
      private IEnumerable<SelectListItem> getPurposelist()
        {
            var list = _unitOfWork.purpose.GetAll( orderby: m => m.OrderBy(a => a.Name)).Select(i => new SelectListItem()
            {
                Text = i.Name,
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

                                  }).ToListAsync();
            var list = userList.Select(i => new SelectListItem()
            {
                Text = i.FullName,
                Value = i.UserId.ToString()
            });

            return list;
        }
    }
}
