using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace wbzf.Model.ViewModel
{
    public class CommonUserRgistration
    {
       
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password does not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Profile Name")]
        public string Full_Name { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ImageUrl { get; set; }
        [Required]
        [Display(Name = "Mother Name")]
        public string Mother_Name { get; set; }
        [Required]
        [Display(Name = "Mobile No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }

        public string? Vill { get; set; }
        public string? PostOffice { get; set; }
        public string? PoliceStation { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
        [Required]
        [Display(Name = "PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code.")]

        public string? PIN { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? ProfessionId { get; set; }
        [ValidateNever]
        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }
        public double? fatherIncome { get; set; }
        public double? motherIncome { get; set; }
        public string? parentType { get; set; }
        public string? guardianName { get; set; }
        public int? guardianOccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("guardianOccupationId")]
        public virtual Profession guardianOccupation { get; set; }
        public int? fatherOccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("fatherOccupationId")]
        public virtual Profession fatherOccupation { get; set; }
        public int? motherOccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("motherOccupationId")]
        public virtual Profession motherOccupation { get; set; }
        public double? guardianIncome { get; set; }
        public string? bankName { get; set; }
        public string? bankIFSC { get; set; }
        public string? bankBranchName { get; set; }
        public string? bankAcNo { get; set; }
        [Required]
        [Display(Name = "Aadhaar Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public string? adhaarno { get; set; }
        public string? category { get; set; }
        public string? adhaarUrl { get; set; }
        public string? passbookUrl { get; set; }
        public string? FatherName { get; set; }
        public string? relation_with_guardian { get; set; }
        public int? SchemeId { get; set; }
        [ValidateNever]
        [ForeignKey("SchemeId")]
        public virtual Scheme Scheme { get; set; }
        public int? PurposeId { get; set; }
        [ValidateNever]
        [ForeignKey("PurposeId")]
        public virtual Purpose Purpose { get; set; }


    }
}
