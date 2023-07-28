using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class testimonial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Designation { get; set; }
        public string? ImageUrl { get; set; }
        public string statement { get; set; }
        public int DisplayOrder { get; set; }
    }
}
