using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.Utility
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string ScrutinyOfficer = "Scrutiny Officer";
        public const string FinanceOfficer = "Finance Officer";
        public const string Donor = "Donor";
        public const string Beneficiary = "Beneficiary";

        public const string Incomplete = "Incomplete";
        public const string Draft = "Draft";
        public const string Complete = "Complete";
        public const string Applied = "Applied";
        public const string InProgress = "In Progress";
        public const string Approved = "Approved and Admitted";
        public const string Rejected = "Rejected";
        public const string Verified = "Verified";
        public const string Sanctioned = "Sanctioned";
       

        public const string OurTeamMembers = "Our Team Members";
        public const string OurAdvisoryCommitte = "Advisory Committee";
        public const string OurMufti = "Mufti / Islamic Scholar";
        public const string OurAuditor = "Auditor";
        public const string OurLegalExpert = "Legal Expert";
        public const string OurMembers = "Members";

        public const string Father = "Father";
        public const string Mother = "Mother";
        public const string Guardian = "Guardian";




        public const string WBCS = "WBCS";
        public const string WBJS = "WBJS";


        public const string Zakat = "Zakat";
        public const string Interest = "Interest";
        public const string Donation = "Donation";

        public const string created = "created";
        public const string authorized = "authorized";
        public const string paid = "paid";
        public const string failed = "failed";

        public const string Utilized = "Utilized";
        public const string notUtilized = "Not Utilized";

        public const string GEN = "General";
        public const string OBC_A = "OBC-A";
        public const string OBC_B = "OBC-B";
        public const string SC = "SC";
        public const string ST = "ST";

        public const string auditReport = "Audit Report";
        public const string annualReport = "Annual Report";
        public const string specialReport = "Special Report";


        //Purpose area
        public const string Education = "Education";
        public const string Health = "Health";
        public const string Social_Welfare = "Social Welfare";
        public const string Business_Assistance = "Business Assistance";

        //Payment Mode
        public const string Cash = "Cash";
        public const string Online = "Online";
        public const string Fine = "Fine";
        //Account Transaction Purpose
        public const string Deposite = "Deposite";
        public const string Salary = "Salary";
        public const string Expence = "Expence";
        public const string Account_Transfer = "Account Transfer";
        public const string Success = "Success";
        public const string Refund = "Refund";


        // balance Calculate
        public const string Add = "Add";
        public const string Substract = "Substract";
    }
}
