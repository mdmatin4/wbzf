using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class Smtp
    {

        public string? host { get; set; }
        public string? port { get; set; }
        public string? fromEmail { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }

    }
}
