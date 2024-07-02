using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.DataAccess.Repository
{
    public class ApplicationRegisterRepository : Repository<ApplicationRegister>, IApplicationRegisterRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationRegisterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void update(ApplicationRegister appReg)
        {
            var objFromDb = _db.application_register.FirstOrDefault(u => u.Id == appReg.Id);
            if (objFromDb != null)
            {
                appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);

                if (appReg.Full_Name != null)
                {
                    objFromDb.Full_Name = appReg.Full_Name;
                }
              
                if (appReg.application_Status != null)
                {
                    objFromDb.application_Status = appReg.application_Status;
                }
                if (appReg.Gender != null)
                {
                    objFromDb.Gender = appReg.Gender;
                }
                if (appReg.ProfessionId != null)
                {
                    objFromDb.ProfessionId = appReg.ProfessionId;
                }
                if (appReg.category != null)
                {
                    objFromDb.category = appReg.category;
                }
                if (appReg.DateofBirth != null)
                {
                    objFromDb.DateofBirth = appReg.DateofBirth;
                }
                if (appReg.adhaarno != null)
                {
                    objFromDb.adhaarno = appReg.adhaarno;
                }
                if (appReg.PhoneNumber != null)
                {
                    objFromDb.PhoneNumber = appReg.PhoneNumber;
                }
                if (appReg.Email != null)
                {
                    objFromDb.Email = appReg.Email;
                }
                if (appReg.parentType != null)
                {
                    objFromDb.parentType = appReg.parentType;
                }
                if (appReg.Mother_name != null)
                {
                    objFromDb.Mother_name = appReg.Mother_name;
                }
                if (appReg.father_OccupationId != null)
                {
                    objFromDb.father_OccupationId = appReg.father_OccupationId;
                }
                if (appReg.mother_OccupationId != null)
                {
                    objFromDb.mother_OccupationId = appReg.mother_OccupationId;
                }
                if (appReg.guardian_OccupationId != null)
                {
                    objFromDb.guardian_OccupationId = appReg.guardian_OccupationId;
                }
                if (appReg.Father_name != null)
                {
                    objFromDb.Father_name = appReg.Father_name;
                }
                if (appReg.guardianName != null)
                {
                    objFromDb.guardianName = appReg.guardianName;
                }
                if (appReg.relation_with_guardian != null)
                {
                    objFromDb.relation_with_guardian = appReg.relation_with_guardian;
                }
                if (appReg.fatherIncome != null)
                {
                    objFromDb.fatherIncome = appReg.fatherIncome;
                }
                if (appReg.motherIncome != null)
                {
                    objFromDb.motherIncome = appReg.motherIncome;
                }
                if (appReg.guardianIncome != null)
                {
                    objFromDb.guardianIncome = appReg.guardianIncome;
                }
                if (appReg.Vill != null)
                {
                    objFromDb.Vill = appReg.Vill;
                }
                if (appReg.PostOffice != null)
                {
                    objFromDb.PostOffice = appReg.PostOffice;
                }
                if (appReg.PoliceStation != null)
                {
                    objFromDb.PoliceStation = appReg.PoliceStation;
                }
                if (appReg.District != null)
                {
                    objFromDb.District = appReg.District;
                }
                if (appReg.State != null)
                {
                    objFromDb.State = appReg.State;
                }
                if (appReg.PIN != null)
                {
                    objFromDb.PIN = appReg.PIN;
                }
                if (appReg.bankAcNo != null)
                {
                    objFromDb.bankAcNo = appReg.bankAcNo;
                }
                if (appReg.bankName != null)
                {
                    objFromDb.bankName = appReg.bankName;
                }
                if (appReg.bankBranchName != null)
                {
                    objFromDb.bankBranchName = appReg.bankBranchName;
                }
                if (appReg.bankIFSC != null)
                {
                    objFromDb.bankIFSC = appReg.bankIFSC;
                }
                if (appReg.Photo_url != null)
                {
                    objFromDb.Photo_url = appReg.Photo_url;
                }
                if (appReg.adhaarUrl != null)
                {
                    objFromDb.adhaarUrl = appReg.adhaarUrl;
                }
                if (appReg.passbookUrl != null)
                {
                    objFromDb.passbookUrl = appReg.passbookUrl;
                }
                if (appReg.sign_url != null)
                {
                    objFromDb.sign_url = appReg.sign_url;
                }
                if (appReg.incomeproof_url != null)
                {
                    objFromDb.incomeproof_url = appReg.incomeproof_url;
                }
                if (appReg.admissionreceipt_url != null)
                {
                    objFromDb.admissionreceipt_url = appReg.admissionreceipt_url;
                }
                if (appReg.admit_url != null)
                {
                    objFromDb.admit_url = appReg.admit_url;
                }
                if (appReg.marksheet_url != null)
                {
                    objFromDb.marksheet_url = appReg.marksheet_url;
                }
                if (appReg.category_url != null)
                {
                    objFromDb.category_url = appReg.category_url;
                }
                if (appReg.Prescription_url != null)
                {
                    objFromDb.Prescription_url = appReg.Prescription_url;
                }
                if (appReg.bonafied_certificate_url != null)
                {
                    objFromDb.bonafied_certificate_url = appReg.bonafied_certificate_url;
                }
                if (appReg.course_name != null)
                {
                    objFromDb.course_name = appReg.course_name;
                }
                if (appReg.course_duration != null)
                {
                    objFromDb.course_duration = appReg.course_duration;
                }
                if (appReg.present_class != null)
                {
                    objFromDb.present_class = appReg.present_class;
                }
                if (appReg.Registration_Number != null)
                {
                    objFromDb.Registration_Number = appReg.Registration_Number;
                }
                if (appReg.Institute_admission_date != null)
                {
                    objFromDb.Institute_admission_date = appReg.Institute_admission_date;
                }
                if (appReg.Institute_Name != null)
                {
                    objFromDb.Institute_Name = appReg.Institute_Name;
                }
                if (appReg.passing_year != null)
                {
                    objFromDb.passing_year = appReg.passing_year;
                }
                if (appReg.last_exam != null)
                {
                    objFromDb.last_exam = appReg.last_exam;
                }
                if (appReg.past_institute != null)
                {
                    objFromDb.past_institute = appReg.past_institute;
                }
                if (appReg.full_marks != null)
                {
                    objFromDb.full_marks = appReg.full_marks;
                }
                if (appReg.obtain_marks != null)
                {
                    objFromDb.obtain_marks = appReg.obtain_marks;
                }
                if (appReg.percentage != null)
                {
                    objFromDb.percentage = appReg.percentage;
                }
                if (appReg.Institute_Contact != null)
                {
                    objFromDb.Institute_Contact = appReg.Institute_Contact;
                }
                if (appReg.Institute_Address != null)
                {
                    objFromDb.Institute_Address = appReg.Institute_Address;
                }
                if (appReg.Is_Past_Scholar != null)
                {
                    objFromDb.Is_Past_Scholar = appReg.Is_Past_Scholar;
                }
                if (appReg.Past_Scholar_Name != null)
                {
                    objFromDb.Past_Scholar_Name = appReg.Past_Scholar_Name;
                }
                if (appReg.Past_Scholar_Amount != null)
                {
                    objFromDb.Past_Scholar_Amount = appReg.Past_Scholar_Amount;
                }
                if (appReg.Institute_Admission_fees != null)
                {
                    objFromDb.Institute_Admission_fees = appReg.Institute_Admission_fees;
                }
                if (appReg.Tuition_fees != null)
                {
                    objFromDb.Tuition_fees = appReg.Tuition_fees;
                }
                if (appReg.Exam_fees != null)
                {
                    objFromDb.Exam_fees = appReg.Exam_fees;
                }
                if (appReg.Institute_Other_fees != null)
                {
                    objFromDb.Institute_Other_fees = appReg.Institute_Other_fees;
                }
                if (appReg.Hospital_admission_date != null)
                {
                    objFromDb.Hospital_admission_date = appReg.Hospital_admission_date;
                }
                if (appReg.Hospital_Name != null)
                {
                    objFromDb.Hospital_Name = appReg.Hospital_Name;
                }
                if (appReg.Hospital_Address != null)
                {
                    objFromDb.Hospital_Address = appReg.Hospital_Address;
                }
                if (appReg.Hospital_Contact != null)
                {
                    objFromDb.Hospital_Contact = appReg.Hospital_Contact;
                }
                if (appReg.Hospital_Admission_Number != null)
                {
                    objFromDb.Hospital_Admission_Number = appReg.Hospital_Admission_Number;
                }
                if (appReg.Hospital_Ward_Number != null)
                {
                    objFromDb.Hospital_Ward_Number = appReg.Hospital_Ward_Number;
                }
                if (appReg.Hospital_Bed_Number != null)
                {
                    objFromDb.Hospital_Bed_Number = appReg.Hospital_Bed_Number;
                }
                if (appReg.Illness_Period != null)
                {
                    objFromDb.Illness_Period = appReg.Illness_Period;
                }
                if (appReg.Doctor_Name != null)
                {
                    objFromDb.Doctor_Name = appReg.Doctor_Name;
                }
                if (appReg.Doctor_Contact != null)
                {
                    objFromDb.Doctor_Contact = appReg.Doctor_Contact;
                }
                if (appReg.Is_Admit != null)
                {
                    objFromDb.Is_Admit = appReg.Is_Admit;
                }
                if (appReg.Is_Delete != null)
                {
                    objFromDb.Is_Delete = appReg.Is_Delete;
                }
                if (appReg.Hospital_Admission_fees != null)
                {
                    objFromDb.Hospital_Admission_fees = appReg.Hospital_Admission_fees;
                }
                if (appReg.Hospital_Bed_fees != null)
                {
                    objFromDb.Hospital_Bed_fees = appReg.Hospital_Bed_fees;
                }
                if (appReg.Hospital_Surgery_fees != null)
                {
                    objFromDb.Hospital_Surgery_fees = appReg.Hospital_Surgery_fees;
                }
                if (appReg.Medicine_fees != null)
                {
                    objFromDb.Medicine_fees = appReg.Medicine_fees;
                }
                if (appReg.Hospital_Other_fees != null)
                {
                    objFromDb.Hospital_Other_fees = appReg.Hospital_Other_fees;
                }
                if (appReg.Treatment_Estimate_cost != null)
                {
                    objFromDb.Treatment_Estimate_cost = appReg.Treatment_Estimate_cost;
                }
                if (appReg.Prayer_amount != null)
                {
                    objFromDb.Prayer_amount = appReg.Prayer_amount;
                }
                if (appReg.Is_insured != null)
                {
                    objFromDb.Is_insured = appReg.Is_insured;
                }
                if (appReg.Insured_amt != null)
                {
                    objFromDb.Insured_amt = appReg.Insured_amt;
                }
                if (appReg.Ref1_Member_name != null)
                {
                    objFromDb.Ref1_Member_name = appReg.Ref1_Member_name;
                }
                if (appReg.Ref1_Member_Contact != null)
                {
                    objFromDb.Ref1_Member_Contact = appReg.Ref1_Member_Contact;
                }
                if (appReg.R1_Member_OccupationId != null)
                {
                    objFromDb.R1_Member_OccupationId = appReg.R1_Member_OccupationId;
                }
                if (appReg.Ref2_Member_name != null)
                {
                    objFromDb.Ref2_Member_name = appReg.Ref2_Member_name;
                }
                if (appReg.Ref2_Member_Contact != null)
                {
                    objFromDb.Ref2_Member_Contact = appReg.Ref2_Member_Contact;
                }
                if (appReg.R2_Member_OccupationId != null)
                {
                    objFromDb.R2_Member_OccupationId = appReg.R2_Member_OccupationId;
                }

            }
        }
        public void updation(ApplicationRegister appReg)
        {
            var objFromDb = _db.application_register.FirstOrDefault(u => u.Id == appReg.Id);
            if (objFromDb != null)
            {
                appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);

                if (appReg.Full_Name != null)
                {
                    objFromDb.Full_Name = appReg.Full_Name;
                }
                if (appReg.Gender != null)
                {
                    objFromDb.Gender = appReg.Gender;
                }
                if (appReg.ProfessionId != null)
                {
                    objFromDb.ProfessionId = appReg.ProfessionId;
                }
                if (appReg.category != null)
                {
                    objFromDb.category = appReg.category;
                }
                if (appReg.DateofBirth != null)
                {
                    objFromDb.DateofBirth = appReg.DateofBirth;
                }
                if (appReg.adhaarno != null)
                {
                    objFromDb.adhaarno = appReg.adhaarno;
                }
                if (appReg.PhoneNumber != null)
                {
                    objFromDb.PhoneNumber = appReg.PhoneNumber;
                }
                if (appReg.Email != null)
                {
                    objFromDb.Email = appReg.Email;
                }
                if (appReg.parentType != null)
                {
                    objFromDb.parentType = appReg.parentType;
                }
                if (appReg.Mother_name != null)
                {
                    objFromDb.Mother_name = appReg.Mother_name;
                }
                if (appReg.father_OccupationId != null)
                {
                    objFromDb.father_OccupationId = appReg.father_OccupationId;
                }
                if (appReg.mother_OccupationId != null)
                {
                    objFromDb.mother_OccupationId = appReg.mother_OccupationId;
                }
                if (appReg.guardian_OccupationId != null)
                {
                    objFromDb.guardian_OccupationId = appReg.guardian_OccupationId;
                }
                if (appReg.Father_name != null)
                {
                    objFromDb.Father_name = appReg.Father_name;
                }
                if (appReg.guardianName != null)
                {
                    objFromDb.guardianName = appReg.guardianName;
                }
                if (appReg.relation_with_guardian != null)
                {
                    objFromDb.relation_with_guardian = appReg.relation_with_guardian;
                }
                if (appReg.fatherIncome != null)
                {
                    objFromDb.fatherIncome = appReg.fatherIncome;
                }
                if (appReg.motherIncome != null)
                {
                    objFromDb.motherIncome = appReg.motherIncome;
                }
                if (appReg.guardianIncome != null)
                {
                    objFromDb.guardianIncome = appReg.guardianIncome;
                }
                if (appReg.Vill != null)
                {
                    objFromDb.Vill = appReg.Vill;
                }
                if (appReg.PostOffice != null)
                {
                    objFromDb.PostOffice = appReg.PostOffice;
                }
                if (appReg.PoliceStation != null)
                {
                    objFromDb.PoliceStation = appReg.PoliceStation;
                }
                if (appReg.District != null)
                {
                    objFromDb.District = appReg.District;
                }
                if (appReg.State != null)
                {
                    objFromDb.State = appReg.State;
                }
                if (appReg.PIN != null)
                {
                    objFromDb.PIN = appReg.PIN;
                }
                if (appReg.bankAcNo != null)
                {
                    objFromDb.bankAcNo = appReg.bankAcNo;
                }
                if (appReg.bankName != null)
                {
                    objFromDb.bankName = appReg.bankName;
                }
                if (appReg.bankBranchName != null)
                {
                    objFromDb.bankBranchName = appReg.bankBranchName;
                }
                if (appReg.bankIFSC != null)
                {
                    objFromDb.bankIFSC = appReg.bankIFSC;
                }
                if (appReg.Photo_url != null)
                {
                    objFromDb.Photo_url = appReg.Photo_url;
                }
                if (appReg.adhaarUrl != null)
                {
                    objFromDb.adhaarUrl = appReg.adhaarUrl;
                }
                if (appReg.passbookUrl != null)
                {
                    objFromDb.passbookUrl = appReg.passbookUrl;
                }
                if (appReg.sign_url != null)
                {
                    objFromDb.sign_url = appReg.sign_url;
                }
                if (appReg.incomeproof_url != null)
                {
                    objFromDb.incomeproof_url = appReg.incomeproof_url;
                }
                if (appReg.admissionreceipt_url != null)
                {
                    objFromDb.admissionreceipt_url = appReg.admissionreceipt_url;
                }
                if (appReg.admit_url != null)
                {
                    objFromDb.admit_url = appReg.admit_url;
                }
                if (appReg.marksheet_url != null)
                {
                    objFromDb.marksheet_url = appReg.marksheet_url;
                }
                if (appReg.category_url != null)
                {
                    objFromDb.category_url = appReg.category_url;
                }
                if (appReg.Prescription_url != null)
                {
                    objFromDb.Prescription_url = appReg.Prescription_url;
                }
                if (appReg.bonafied_certificate_url != null)
                {
                    objFromDb.bonafied_certificate_url = appReg.bonafied_certificate_url;
                }
                if (appReg.course_name != null)
                {
                    objFromDb.course_name = appReg.course_name;
                }
                if (appReg.course_duration != null)
                {
                    objFromDb.course_duration = appReg.course_duration;
                }
                if (appReg.present_class != null)
                {
                    objFromDb.present_class = appReg.present_class;
                }
                if (appReg.Registration_Number != null)
                {
                    objFromDb.Registration_Number = appReg.Registration_Number;
                }
                if (appReg.Institute_admission_date != null)
                {
                    objFromDb.Institute_admission_date = appReg.Institute_admission_date;
                }
                if (appReg.Institute_Name != null)
                {
                    objFromDb.Institute_Name = appReg.Institute_Name;
                }
                if (appReg.passing_year != null)
                {
                    objFromDb.passing_year = appReg.passing_year;
                }
                if (appReg.last_exam != null)
                {
                    objFromDb.last_exam = appReg.last_exam;
                }
                if (appReg.past_institute != null)
                {
                    objFromDb.past_institute = appReg.past_institute;
                }
                if (appReg.full_marks != null)
                {
                    objFromDb.full_marks = appReg.full_marks;
                }
                if (appReg.obtain_marks != null)
                {
                    objFromDb.obtain_marks = appReg.obtain_marks;
                }
                if (appReg.percentage != null)
                {
                    objFromDb.percentage = appReg.percentage;
                }
                if (appReg.Institute_Contact != null)
                {
                    objFromDb.Institute_Contact = appReg.Institute_Contact;
                }
                if (appReg.Institute_Address != null)
                {
                    objFromDb.Institute_Address = appReg.Institute_Address;
                }
                if (appReg.Is_Past_Scholar != null)
                {
                    objFromDb.Is_Past_Scholar = appReg.Is_Past_Scholar;
                }
                if (appReg.Past_Scholar_Name != null)
                {
                    objFromDb.Past_Scholar_Name = appReg.Past_Scholar_Name;
                }
                if (appReg.Past_Scholar_Amount != null)
                {
                    objFromDb.Past_Scholar_Amount = appReg.Past_Scholar_Amount;
                }
                if (appReg.Institute_Admission_fees != null)
                {
                    objFromDb.Institute_Admission_fees = appReg.Institute_Admission_fees;
                }
                if (appReg.Tuition_fees != null)
                {
                    objFromDb.Tuition_fees = appReg.Tuition_fees;
                }
                if (appReg.Exam_fees != null)
                {
                    objFromDb.Exam_fees = appReg.Exam_fees;
                }
                if (appReg.Institute_Other_fees != null)
                {
                    objFromDb.Institute_Other_fees = appReg.Institute_Other_fees;
                }
                if (appReg.Hospital_admission_date != null)
                {
                    objFromDb.Hospital_admission_date = appReg.Hospital_admission_date;
                }
                if (appReg.Hospital_Name != null)
                {
                    objFromDb.Hospital_Name = appReg.Hospital_Name;
                }
                if (appReg.Hospital_Address != null)
                {
                    objFromDb.Hospital_Address = appReg.Hospital_Address;
                }
                if (appReg.Hospital_Contact != null)
                {
                    objFromDb.Hospital_Contact = appReg.Hospital_Contact;
                }
                if (appReg.Hospital_Admission_Number != null)
                {
                    objFromDb.Hospital_Admission_Number = appReg.Hospital_Admission_Number;
                }
                if (appReg.Hospital_Ward_Number != null)
                {
                    objFromDb.Hospital_Ward_Number = appReg.Hospital_Ward_Number;
                }
                if (appReg.Hospital_Bed_Number != null)
                {
                    objFromDb.Hospital_Bed_Number = appReg.Hospital_Bed_Number;
                }
                if (appReg.Illness_Period != null)
                {
                    objFromDb.Illness_Period = appReg.Illness_Period;
                }
                if (appReg.Doctor_Name != null)
                {
                    objFromDb.Doctor_Name = appReg.Doctor_Name;
                }
                if (appReg.Doctor_Contact != null)
                {
                    objFromDb.Doctor_Contact = appReg.Doctor_Contact;
                }
                if (appReg.Is_Admit != null)
                {
                    objFromDb.Is_Admit = appReg.Is_Admit;
                }
                if (appReg.Is_Delete != null)
                {
                    objFromDb.Is_Delete = appReg.Is_Delete;
                }
                if (appReg.Hospital_Admission_fees != null)
                {
                    objFromDb.Hospital_Admission_fees = appReg.Hospital_Admission_fees;
                }
                if (appReg.Hospital_Bed_fees != null)
                {
                    objFromDb.Hospital_Bed_fees = appReg.Hospital_Bed_fees;
                }
                if (appReg.Hospital_Surgery_fees != null)
                {
                    objFromDb.Hospital_Surgery_fees = appReg.Hospital_Surgery_fees;
                }
                if (appReg.Medicine_fees != null)
                {
                    objFromDb.Medicine_fees = appReg.Medicine_fees;
                }
                if (appReg.Hospital_Other_fees != null)
                {
                    objFromDb.Hospital_Other_fees = appReg.Hospital_Other_fees;
                }
                if (appReg.Treatment_Estimate_cost != null)
                {
                    objFromDb.Treatment_Estimate_cost = appReg.Treatment_Estimate_cost;
                }
                if (appReg.Prayer_amount != null)
                {
                    objFromDb.Prayer_amount = appReg.Prayer_amount;
                }
                if (appReg.Is_insured != null)
                {
                    objFromDb.Is_insured = appReg.Is_insured;
                }
                if (appReg.Insured_amt != null)
                {
                    objFromDb.Insured_amt = appReg.Insured_amt;
                }
                if (appReg.Ref1_Member_name != null)
                {
                    objFromDb.Ref1_Member_name = appReg.Ref1_Member_name;
                }
                if (appReg.Ref1_Member_Contact != null)
                {
                    objFromDb.Ref1_Member_Contact = appReg.Ref1_Member_Contact;
                }
                if (appReg.R1_Member_OccupationId != null)
                {
                    objFromDb.R1_Member_OccupationId = appReg.R1_Member_OccupationId;
                }
                if (appReg.Ref2_Member_name != null)
                {
                    objFromDb.Ref2_Member_name = appReg.Ref2_Member_name;
                }
                if (appReg.Ref2_Member_Contact != null)
                {
                    objFromDb.Ref2_Member_Contact = appReg.Ref2_Member_Contact;
                }
                if (appReg.R2_Member_OccupationId != null)
                {
                    objFromDb.R2_Member_OccupationId = appReg.R2_Member_OccupationId;
                }
               
            }
        }
        public void Verify(ApplicationRegister appReg)
        {
            var objFromDb = _db.application_register.FirstOrDefault(u => u.Id == appReg.Id);
            if (objFromDb != null)
            {
                appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);

                if (appReg.application_Status != null)
                {
                    objFromDb.application_Status = SD.Verified;
                }

            }
        }
         public void Sanction(ApplicationRegister appReg)
        {
            var objFromDb = _db.application_register.FirstOrDefault(u => u.Id == appReg.Id);
            if (objFromDb != null)
            {
                appReg.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);

                if (appReg.application_Status != null)
                {
                    objFromDb.application_Status = SD.Sanctioned;
                }
                 if (appReg.Sanction_Amount != null)
                {
                    objFromDb.Sanction_Amount = appReg.Sanction_Amount;
                }

            }
        }

    }

}
