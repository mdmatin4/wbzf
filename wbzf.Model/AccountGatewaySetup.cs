using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class AccountGatewaySetup
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        [ValidateNever]
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public int PaymentGatewayId { get; set; }
        [ValidateNever]
        [ForeignKey("PaymentGatewayId")]
        public virtual PaymentGateway PaymentGateway { get; set; }
        public string? SecretName { get; set; }
        public string? secretValue { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
