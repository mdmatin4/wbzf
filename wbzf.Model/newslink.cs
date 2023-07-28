using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class newslink
    {
        public int Id { get; set; }
        [Display(Name ="News Headline")]
        public string Title { get; set; }
        public DateTime? publish_date { get; set; }
        [Display(Name ="Media Copamy Name")]
        public string? NewsOrganizationName { get; set; }
        public string? NewsLink { get; set; }
        public string ImageUrl { get; set; }
        public int displayOrder { get; set; }
    }
}
