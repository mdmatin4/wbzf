using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class Purpose
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public string? Form_url { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

    }
}
