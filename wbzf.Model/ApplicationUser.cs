using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
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
        public virtual Profession Profession { get; set; }
        public int? familyIncome { get; set; }
        public string? parentType { get; set; }
        public string? guardianName { get; set; }
        public int? guardianOccupationId   { get; set; }
        [ValidateNever]
        [ForeignKey("guardianOccupationId")]
        public virtual Profession Occupation { get; set; }
        public int? guardianIncome { get; set; }
        public string? bankName { get; set; }
        public string? bankIFSC { get; set; }
        public  string? bankBranchName { get; set; }
        public string? bankAcNo { get; set; }



    }
}
