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
    public class ApplicationProcessing
    {
        [Required]
        public string Id { get; set; }

        public string ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        [ValidateNever]
        public ApplicationRegister? Applications { get; set; }
        public string? VerifierId { get; set; }
        [ForeignKey("VerifierId")]
        [ValidateNever]
        public ApplicationUser? Verify_by { get; set; }
        public string? ApproverId { get; set; }
        [ForeignKey("ApproverId")]
        [ValidateNever]
        public ApplicationUser? Approved_by { get; set; }
        public DateTime? Verify_at { get; set; }
        public DateTime? Approved_at { get; set; }
        public ApplicationProcessing()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
