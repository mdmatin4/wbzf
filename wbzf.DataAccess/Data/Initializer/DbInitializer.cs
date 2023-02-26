using wbzf.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Utility;
using wbzf.DataAccess.Data;

namespace wbzf.DataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db=db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (!_roleManager.RoleExistsAsync(SD.Donor).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Donor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Beneficiary)).GetAwaiter().GetResult();
            }

            if (!_roleManager.RoleExistsAsync(SD.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Manager)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.ScrutinyOfficer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.FinanceOfficer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Donor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Beneficiary)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@wbzf.org",
                    Email = "admin@wbzf.org",
                    EmailConfirmed = true,
                    Full_Name="West Bengal Zakat Foundation"
                }, "Wbzf123*").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUser.FirstOrDefault(u => u.Email == "admin@wbzf.org");

                _userManager.AddToRoleAsync(user, SD.Admin).GetAwaiter().GetResult();



            }
            return;
        }
    }
}
