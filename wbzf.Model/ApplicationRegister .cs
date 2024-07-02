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
    public class ApplicationRegister
    {
        [Required]
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public int? SchemeId { get; set; }
        [ValidateNever]
        [ForeignKey("SchemeId")]
        public virtual Scheme Scheme { get; set; }
        public int? PurposeId { get; set; }
        [ValidateNever]
        [ForeignKey("PurposeId")]
        public virtual Purpose Purpose { get; set; }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        [Required]
        public string? Full_Name { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Picture")]
        public string? Photo_url { get; set; }
        public string? Vill { get; set; }
        public string? PostOffice { get; set; }
        public string? PoliceStation { get; set; }
        public string? District { get; set; }
        public string? State { get; set; }
       
        [Display(Name = "PIN")]
        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid Pin Code.")]

        public string? PIN { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? ProfessionId { get; set; }
        [ValidateNever]
        [ForeignKey("ProfessionId")]
        public virtual Profession? Profession { get; set; }
        public double? fatherIncome { get; set; }
        public double? motherIncome { get; set; }
        public double? guardianIncome { get; set; }
        public string? parentType { get; set; }
        public string? guardianName { get; set; }
        public int? guardian_OccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("guardian_OccupationId")]
        public virtual Profession? guardianOccupation { get; set; }
        public int? father_OccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("father_OccupationId")]
        public virtual Profession? fatherOccupation { get; set; }
        public int? mother_OccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("mother_OccupationId")]
        public virtual Profession? motherOccupation { get; set; }
        public string? bankName { get; set; }
        public string? bankIFSC { get; set; }
        public string? bankBranchName { get; set; }
        public string? bankAcNo { get; set; }
        public string? application_Status { get; set; }
     
        [Display(Name = "Aadhaar Number")]
        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Aadhaar Number.")]
        public string? adhaarno { get; set; }
        public string? category { get; set; }
        public string? adhaarUrl { get; set; }
        public string? passbookUrl { get; set; }
        public string? incomeproof_url { get; set; }

        public string? admit_url { get; set; }

        public string? marksheet_url { get; set; }

        public string? admissionreceipt_url { get; set; }
        public string? Father_name { get; set; }
        public string? Mother_name { get; set; }
        public string? relation_with_guardian { get; set; }
        public string? sign_url { get; set; }
        public string? course_name { get; set; }
        public string? present_class { get; set; }
        public string? course_duration { get; set; }
        public string? Registration_Number { get; set; }
        public DateTime? Institute_admission_date { get; set; }
        public string? last_exam {  get; set; }
        public string? past_institute { get; set; }
        public int ? full_marks { get; set; }
        public int ? obtain_marks { get; set; }
        public double ? percentage { get; set; }
         public int ? passing_year { get; set; }
        public string? Institute_Name { get; set; }
        public string? Institute_Address { get; set; }
   
        [Display(Name = "Institute Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Institute Contact Number.")]
        public string? Institute_Contact { get; set; }
        public bool? Is_Past_Scholar { get; set; }
        public DateTime? Past_Scholar_date { get; set; }
        public string? Past_Scholar_Name { get; set; }
        public double? Past_Scholar_Amount { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Invalid Admission Fee.")]
        public double? Institute_Admission_fees { get; set; }
        public double? Tuition_fees { get; set; }
        public double? Exam_fees { get; set; }
        public double? Institute_Other_fees { get; set; }
        public DateTime? Hospital_admission_date { get; set; }
        public string? Hospital_Name { get; set; }
        public string? Hospital_Admission_Number { get; set; }
        public string? Hospital_Ward_Number { get; set; }
        public string? Hospital_Bed_Number { get; set; }
        public string? Illness_Period { get; set; }
        public string? Doctor_Name { get; set; }
      
        [Display(Name = "Doctor Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Doctor Contact Number.")]

        public string? Doctor_Contact { get; set; }
        public bool? Is_Admit { get; set; }
        public bool? Is_Delete { get; set; }
        public string? Hospital_Address { get; set; }
       
        [Display(Name = "Hospital Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Hospital Contact Number.")]

        public string? Hospital_Contact { get; set; }
        public double? Hospital_Admission_fees { get; set; }
        public double? Hospital_Bed_fees { get; set; }
        public double? Hospital_Surgery_fees { get; set; }
        public double? Hospital_Other_fees { get; set; }
        public double? Medicine_fees { get; set; }
        public double? Treatment_Estimate_cost { get; set; }
        public double? Prayer_amount { get; set; }
        public bool? Is_insured { get; set; }
        public double? Insured_amt { get; set; }
        public double? Claim_Amount { get; set; }
        public string? Insurance_Name { get; set; }
        public DateTime? Insurance_Claimed_date { get; set; }

        public string? Ref1_Member_name { get; set; }
       
        [Display(Name = "Reference Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Reference Contact Number.")]

        public string? Ref1_Member_Contact { get; set; }
        public string? Ref2_Member_name { get; set; }
       
        [Display(Name = "Reference Contact Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Reference Contact Number.")]

        public string? Ref2_Member_Contact { get; set; }
        public string? bonafied_certificate_url { get; set; }
        public string? Hospital_admission_receipt_url { get; set; }
        public string? Medicine_bill_url { get; set; }
        public string? category_url { get; set; }
        public string? Prescription_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int? R1_Member_OccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("R1_Member_OccupationId")]
        public virtual Profession? R1MemberOccupation { get; set; }

        public int? R2_Member_OccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("R2_Member_OccupationId")]
        public virtual Profession? R2MemberOccupation { get; set; }

        public double? Sanction_Amount { get; set; }

        public ApplicationRegister()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

}
