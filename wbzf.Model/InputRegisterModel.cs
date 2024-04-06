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
    public class InputRegisterModel
    {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Full_Name { get; set; }
        [Required]
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
        public string? PIN { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? ProfessionId { get; set; }
        [ValidateNever]
        [ForeignKey("ProfessionId")]
        public virtual Profession Profession { get; set; }
        public double? familyIncome { get; set; }
        public string? parentType { get; set; }
        public string? guardianName { get; set; }
        public int? guardianOccupationId { get; set; }
        [ValidateNever]
        [ForeignKey("guardianOccupationId")]
        public virtual Profession Occupation { get; set; }
        public int? guardianIncome { get; set; }
        public string? bankName { get; set; }
        public string? bankIFSC { get; set; }
        public string? bankBranchName { get; set; }
        public string? bankAcNo { get; set; }
    }
}
