using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class HomePagaSlide
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
      
        public string SliderMetaText { get; set; }
     
        public string SliderTitle { get; set; }
        public string ButtonLink { get; set; }
        public string ButtonText { get; set; }
        [Display(Name = "Slider Font Color")]
        public string fontColor { get; set; }
        public int slideOrder { get; set; }
    }
}
