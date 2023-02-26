using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class donation
    {
        public int Id { get; set; }
        public string transaction_id { get; set; }
        public string? payment_gateway_orderid { get; set; }
        public string Name { get; set; }

        [Display(Name = "Email/ই-মেল")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        public string? address { get; set; }
        public string? message { get; set; }
       
        public int amount { get; set; }
        public  string? payment_status { get; set; }
        public string? status { get; set; }
        public string type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? completed_at { get; set; }
    }
}
