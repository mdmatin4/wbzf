using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class TransactionHistory
    {
        public string Id { get; set; }
        public int Account_Id { get; set; }
        [ValidateNever]
        [ForeignKey("Account_Id")]
        public virtual Account Accounts { get; set; }
        public int? ToAccount_Id { get; set; }
        [ValidateNever]
        [ForeignKey("ToAccount_Id")]
        public virtual Account? ToAccounts { get; set; }
        public string PayBy_Id { get; set; }
        [ValidateNever]
        [ForeignKey("PayBy_Id")]
        public virtual ApplicationUser PayBy { get; set; }
        public string? PayTo_Id { get; set; }
        [ValidateNever]
        [ForeignKey("PayTo_Id")]
        public virtual ApplicationUser? PayTo { get; set; }
        public double Amount { get; set; }
        public string? Transaction_Mode { get; set; }
        public string Payment_Status { get; set; }
        public string? Transaction_Purpose { get; set; }
        public string? Remarks { get; set; }
        public int? PaymentGetWay_Id { get; set; }
        [ValidateNever]
        [ForeignKey("PaymentGetWay_Id")]
        public virtual PaymentGateway? paymentGateway { get; set; }
        public string? PaymentGetWay_TxnId { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public DateTime? completed_at { get; set; }
        public double? transaction_fees { get; set; }
        public double received_amount { get; set; }

        public TransactionHistory()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
