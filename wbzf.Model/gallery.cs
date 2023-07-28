using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class gallery
    {
        public int Id { get; set; }
        public int filetypeId { get; set; }  //1 for image ,2 for video
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        [ValidateNever]
        [ForeignKey("CategoryId")]
        public virtual galleryCategory Category { get; set; }
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Description { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }


    }
}
