using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class MainAc
    {
        public string Id { get; set; }
        public int Account_Id { get; set; }
        [ValidateNever]
        [ForeignKey("Account_Id")]
        public virtual Account Accounts { get; set; }
        public string Transaction_Id { get; set; }
        [ValidateNever]
        [ForeignKey("Transaction_Id")]
        public virtual TransactionHistory Transactions { get; set; }
        public double? Cr { get; set; }
        public double? Dr { get; set; }
        public double Bal { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }



        public MainAc()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
