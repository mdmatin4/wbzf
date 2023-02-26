using wbzf.Model;
using wbzf.Model.ViewModel;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace wbzf.Areas.Admin.Pages.Users
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
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
            return new List<string>( await _userManager.GetRolesAsync(user));
        }
        public async Task<IActionResult> OnPostLock(string id)
        {
            _unitOfWork.users.LockUser(id,DateTime.Today.AddDays(5900));
            

            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostUnlock(string id)
        {
            _unitOfWork.users.UnlockUser(id);
            

            return RedirectToPage();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var users =await _userManager.Users.ToListAsync();
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
