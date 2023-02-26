﻿using wbzf.Model;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository
{
    public class Users : IUsers
    {
        #region Constructor
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly DateTime EndDate;
        public Users(UserManager<ApplicationUser> userMgr, ApplicationDbContext db)
        {
            EndDate = new DateTime(2222, 06, 06);

            _userManager = userMgr;
            _db=db;
        }
        #endregion
        
        public bool LockUser(string userid, DateTime? endDate)
        {
            if (endDate == null)
                endDate = EndDate;

            var userTask = _userManager.FindByIdAsync(userid);
            userTask.Wait();
            var user = userTask.Result;

            var lockUserTask = _userManager.SetLockoutEnabledAsync(user, true);
            lockUserTask.Wait();

            var lockDateTask = _userManager.SetLockoutEndDateAsync(user, endDate);
            lockDateTask.Wait();

            var updateSecurityStamp = _userManager.UpdateSecurityStampAsync(user);
            updateSecurityStamp.Wait();

            return lockDateTask.Result.Succeeded && lockUserTask.Result.Succeeded;
        }
        public bool UnlockUser(string userid)
        {
            var userTask = _userManager.FindByIdAsync(userid);
            userTask.Wait();
            var user = userTask.Result;

            var lockDisabledTask = _userManager.SetLockoutEnabledAsync(user, false);
            lockDisabledTask.Wait();

            var setLockoutEndDateTask = _userManager.SetLockoutEndDateAsync(user, DateTime.Now - TimeSpan.FromMinutes(1));
            setLockoutEndDateTask.Wait();

            return setLockoutEndDateTask.Result.Succeeded && lockDisabledTask.Result.Succeeded;
        }
    }
}
