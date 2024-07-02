using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class ApplicationUser : IdentityUser
    {
        public string? Full_Name { get; set; }
        public string? Mother_Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Vill { get; set; }
        public string? PostOffice { get; set; }
        public string? PoliceStation { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        public string? PIN { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? ProfessionId { get; set; }
        [ValidateNever]
        [ForeignKey("ProfessionId")]
        public virtual Profession? Profession { get; set; }
        public double? fatherIncome { get; set; }
        public double? motherIncome { get; set; }
        public string? parentType { get; set; }
        public string? guardianName { get; set; }

        public double? guardianIncome { get; set; }
        public string? bankName { get; set; }
        public string? bankIFSC { get; set; }
        public string? bankBranchName { get; set; }
        public string? bankAcNo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
       
        [Display(Name = "Aadhaar Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public string? adhaar_no { get; set; }
        public string? CastCategory { get; set; }
        public string? adharUrl { get; set; }
        public string? passbookUrl { get; set; }
        public string? FatherName { get; set; }
        public string? relation_with_guardian { get; set; }
        public int? FatherOccupation_ID { get; set; }
        [ValidateNever]
        [ForeignKey("FatherOccupationID")]
        public virtual Profession? FatherOccupation { get; set; }
        public int? MotherOccupation_ID { get; set; }
        [ValidateNever]
        [ForeignKey("MotherOccupationID")]            
        public virtual Profession? MotherOccupation { get; set; }
        public int? GuardianOccupation_ID { get; set; }
        [ValidateNever]
        [ForeignKey("GuardianOccupationID")]
        public virtual Profession? GuardianOccupation { get; set; }

    }
}
