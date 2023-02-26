using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model.ViewModel
{
    public class UsersWithRole
    {
        public string UserId { get; set; }
        public string Full_name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
