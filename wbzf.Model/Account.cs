using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account_no { get; set; }
        public string? bankName { get; set; }
        public string? branchName { get; set; }
        public string? ifsc { get; set; }
        public string? micr { get; set; }
        public bool isvisibletoPublic { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
