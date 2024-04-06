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
        public int Id { get; set; }

        public string? userId { get; set; }
        [ValidateNever]
        [ForeignKey("userId")]
        public virtual ApplicationUser User { get; set; }

        public int accountId { get; set; }
        [ValidateNever]
        [ForeignKey("accountId")]
        public virtual Account Account { get; set; }
        
        public string transaction_id { get; set; }
        public int paymentGatewayId { get; set; }
        [ValidateNever]
        [ForeignKey("paymentGatewayId")]
        public virtual PaymentGateway paymentGateway { get; set; }
        public string? payment_gateway_orderid { get; set; }
        public int purposeId { get; set; }
        [ValidateNever]
        [ForeignKey("purposeId")]
        public virtual Purpose Purpose { get; set; }
        public string Name { get; set; }

        [Display(Name = "Email/ই-মেল")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        public string? address { get; set; }
        public string? message { get; set; }

        public decimal donated_amount { get; set; }
        public decimal received_amount { get; set; }
        public decimal transaction_fees { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? completed_at { get; set; }
    }
}
