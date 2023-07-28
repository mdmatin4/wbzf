using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class contactform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        public string Message { get; set; }
        public DateTime Created_at { get; set; }
        public Boolean IsRead { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
