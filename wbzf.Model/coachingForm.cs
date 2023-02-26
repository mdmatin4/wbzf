using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class coachingForm
    {
        public int Id { get; set; }
        //Institute credentials 
        public string application_no { get; set; }
        public string exam_name { get; set; }

        //student credentials
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string aadharno { get; set; }
        public string category { get; set; }
        public string? imageUrl { get; set; }

        //father mother details

        public string guardain_name { get; set; }
        public string guardain_occupation { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string guardian_Mobile { get; set; }

        //contact details

        [Display(Name = "Email/ই-মেল")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        //address
        public string present_address { get; set; }
        public string permanant_address { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [Display(Name = "Whatsapp No/হোয়াটসঅ্যাপ নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Whatsapp Number.")]
        [DataType(DataType.PhoneNumber)]
        public string? Whatsappno { get; set; }

        [Display(Name = "Total Family Income (Annually)")]
        public int family_income { get; set; }

        //for Qualification 1

        public string? qualification1Exam { get; set; }
        public string? qualification1Board { get; set; }
        public string? qualification1Year { get; set; }
        public string? qualification1Marks { get; set; }
        public string? qualification1Sub { get; set; }
        public string? qualification1Class { get; set; }
        public string? qualification1Remarks { get; set; }


        //for Qualification 2

        public string? qualification2Exam { get; set; }
        public string? qualification2Board { get; set; }
        public string? qualification2Year { get; set; }
        public string? qualification2Marks { get; set; }
        public string? qualification2Sub { get; set; }
        public string? qualification2Class { get; set; }
        public string? qualification2Remarks { get; set; }




        //for Qualification 3

        public string? qualification3Exam { get; set; }
        public string? qualification3Board { get; set; }
        public string? qualification3Year { get; set; }
        public string? qualification3Marks { get; set; }
        public string? qualification3Sub { get; set; }
        public string? qualification3Class { get; set; }
        public string? qualification3Remarks { get; set; }

        //for Qualification 4

        public string? qualification4Exam { get; set; }
        public string? qualification4Board { get; set; }
        public string? qualification4Year { get; set; }
        public string? qualification4Marks { get; set; }
        public string? qualification4Sub { get; set; }
        public string? qualification4Class { get; set; }
        public string? qualification4Remarks { get; set; }


        public string? other_qualification { get; set; }
        public string? currently_working { get; set; }
        public bool is_appeared_bafore { get; set; }
        public string? attempt_year { get; set; }
        public bool is_from_zakat_category { get; set; }
        public string status { get; set; }
        public string? remarks { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
