using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class MembersforHome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Designation { get; set; }
        public string role { get; set; }
        public int displayOrder { get; set; }
    }

}
