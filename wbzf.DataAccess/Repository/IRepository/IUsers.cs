using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IUsers
    {
        public bool LockUser(string email, DateTime? endDate);
        public bool UnlockUser(string email);
    }
}
