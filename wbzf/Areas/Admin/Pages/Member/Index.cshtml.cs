using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model.ViewModel;
using wbzf.Model;
using wbzf.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace wbzf.Areas.Admin.Pages.Member
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public IEnumerable<UsersWithRole> userModel { get; set; }

        public IndexModel(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork= unitOfWork;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
        public async Task<IActionResult> OnPostLock(string id)
        {
            _unitOfWork.users.LockUser(id, DateTime.Today.AddDays(5900));


            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostUnlock(string id)
        {
            _unitOfWork.users.UnlockUser(id);


            return RedirectToPage();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var role1Users = await _userManager.GetUsersInRoleAsync(SD.Admin);
            var role2Users = await _userManager.GetUsersInRoleAsync(SD.Manager);
            var role3Users = await _userManager.GetUsersInRoleAsync(SD.ScrutinyOfficer);
            var role4Users = await _userManager.GetUsersInRoleAsync(SD.FinanceOfficer);

            var users = role1Users.Concat(role2Users).Distinct().ToList();
            users=users.Concat(role3Users).Distinct().ToList();
            users=users.Concat(role4Users).Distinct().ToList();

            var userRolesViewModel = new List<UsersWithRole>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UsersWithRole();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.PhoneNumber = user.PhoneNumber;
                thisViewModel.Full_name = user.Full_Name;
                thisViewModel.LockoutEnabled=user.LockoutEnabled;
                thisViewModel.LockoutEnd=user.LockoutEnd;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            userModel=userRolesViewModel;

            return Page();
        }
    }
}
