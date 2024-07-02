using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class donation
    {
        public string Id { get; set; }

        public string? userId { get; set; }
        [ValidateNever]
        [ForeignKey("userId")]
        public virtual ApplicationUser? User { get; set; }

        public int accountId { get; set; }
        [ValidateNever]
        [ForeignKey("accountId")]
        public virtual Account Account { get; set; }
        
        public string transaction_id { get; set; }
        
        public int? purposeId { get; set; }
        [ValidateNever]
        [ForeignKey("purposeId")]
        public virtual Purpose? Purpose { get; set; }
        public string? Name { get; set; }

        [Display(Name = "Email/ই-মেল")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? Mobile { get; set; }
        public string? address { get; set; }
        public string? message { get; set; }
        public string status { get; set; }//utilize/pertially utilize/not utilize
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public donation()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
