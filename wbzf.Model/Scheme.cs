using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class Scheme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsStartEndVisible { get; set; }
        public string? Eligibility { get; set; }
        public bool IsActive { get; set; }

        public string? Form_Url { get; set; }
        public int purposeId { get; set; }
        [ValidateNever]
        [ForeignKey("purposeId")]
        public virtual Purpose Purpose { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
