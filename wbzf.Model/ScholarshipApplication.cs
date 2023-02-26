using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class ScholarshipApplication
    {
        public int Id { get; set; }
        //Institute credentials 
        public string application_no { get; set; }

        //student credentials
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string aadharno { get; set; }
        public string category { get; set; }
        public string? imageUrl { get; set; }

        //father mother details
        [Display(Name = "Name of Father/Mother/Guardain")]
        public string guardain_name { get; set; }
        public string? guardain_occupation { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string guardian_Mobile { get; set; }



        //address
        [Display(Name = "House No / Village/ Para / Ward")]
        public string? Vill_Ward { get; set; }
        public string? Road { get; set; }
        [Display(Name = "Police Station")]
        public string? PS { get; set; }

        public string? PostOffice { get; set; }
        public string District { get; set; }

        [RegularExpression(@"^([0-9]{6})$", ErrorMessage = "Invalid PIN Number.")]

        public string PIN { get; set; }

        [Display(Name = "Mobile No/মোবাইল নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        [Display(Name = "Whatsapp No/হোয়াটসঅ্যাপ নাম্বার")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Whatsapp Number.")]
        [DataType(DataType.PhoneNumber)]
        public string? Whatsappno { get; set; }


        [Display(Name = "Email/ই-মেল")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }



        //particulars regarding Father/Mother/Guardian who supports in applicants studies

        public string? fatheraddress { get; set; }
        public string? fatheroccupation { get; set; }
        public int? fatherincome { get; set; }
        public string? motheraddress { get; set; }
        public string? motheroccupation { get; set; }
        public int? motherincome { get; set; }
        public string guardianaddress { get; set; }
        public string guardianoccupation { get; set; }
        public int guardianincome { get; set; }

        //course details and name of institution

        public string instituteName { get; set; }
        public string instituteAddress { get; set; }
        public string class_course { get; set; }
        public string nature_of_course { get; set; }
        public string duration_of_course { get; set; }
        public DateTime dateofJoining { get; set; }
        public DateTime? dateofCoruseEnd { get; set; }


        //fees structure 
        public int admissionFees { get; set; }
        public string? admissionFeesRemarks { get; set; }
        public int? tutionFees { get; set; }
        public string? tutionFeesRemarks { get; set; }
        public int? sessionCharge { get; set; }
        public string? sessionChargeRemarks { get; set; }
        public int? cautionMoneyDepsoit { get; set; }
        public string? cautionMoneyRemarks { get; set; }
        public int? developementFees { get; set; }
        public string? developementFeesRemarks { get; set; }
        public int? porcessingFees { get; set; }
        public string? porcessingFeesRemarks { get; set; }
        public int? examfees { get; set; }
        public string? examfeesRemarks { get; set; }
        public int? libraryFees { get; set; }
        public string? libraryFeesRemarks { get; set; }
        public int? laboratoryFees { get; set; }
        public string? laboratoryFeesRemarks { get; set; }
        public int? gameFees { get; set; }
        public string? gameFeesRemarks { get; set; }
        public int? miscFees { get; set; }
        public string? miscFeesRemarks { get; set; }

        public int totalFees { get; set; }



        //admission details

        public string? admission_number { get; set; }
        public string? registration_number { get; set; }
        public DateTime? dateofAdmission { get; set; }
        public DateTime? dateofPayment { get; set; }
        public string? paymentreceiptNumber { get; set; }

        //previous scholarship details
        public bool is_in_receiptScholarship { get; set; }
        public string? scholarshipName { get; set; }
        public int? scholarshipAmoutn { get; set; }
        public string? year { get; set; }
        public string? scholarshipDetials { get; set; }



        //applied scholarship details
        public bool is_applied_anyscholarship { get; set; }
        public string? appliedScholarshipName { get; set; }
        public int? appliedScholarshipAmount { get; set; }
        public string? appliedScholarshipDetails { get; set; }

        //Bank details of Applicant

        public string bankName { get; set; }
        public string branchName { get; set; }
        public string bankAcNo { get; set; }
        public string bankIfsc { get; set; }
        public string? bankMicr { get; set; }

        //bank Detials of the Institute

        public string? insBankName { get; set; }
        public string? insBankBranchName { get; set; }
        public string? insBankAcNo { get; set; }
        public string? insBankIfsc { get; set; }
        public string? insBankMicr { get; set; }

        //reference of two persons 

        public string person1Name { get; set; }
        public string person1Designation { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string person1MobileNo { get; set; }
        public string person2Name { get; set; }
        public string person2Designation { get; set; }
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string person2MobileNo { get; set; }

        public string? admitcardUrl { get; set; }
        public string? examResultUrl { get; set; }
        public string? admissionReceiptUrl { get; set; }
        public string? passbookUrl { get; set; }
        public string? aadharCardUrl { get; set; }
        public string? incomeCertificateUrl { get; set; }

        public string status { get; set; }
        public string? remarks { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
