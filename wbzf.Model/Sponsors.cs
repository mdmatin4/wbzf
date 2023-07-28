using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class Sponsor
    {
        public int Id { get; set; }
        [Display(Name ="Name")]
        public string Title { get; set; }
       
        public string? Website { get; set; }
        public string ImageUrl { get; set; }
        public int displayOrder { get; set; }
        public DateTime created_at { get; set; }
    }
}
