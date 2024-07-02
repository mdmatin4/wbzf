using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class SanctionedApplication
    {
        public string Id { get; set; }

        public string ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        [ValidateNever]
        public ApplicationRegister? Applications { get; set; }

        public double? Paid_Amount { get; set; }
        public string Payment_Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public SanctionedApplication()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
