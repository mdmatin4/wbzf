using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace wbzf.Utility
{
    
    public static class Formula
    {
        public static string MakeApplicationIdForExam(string companyshortname,string exam_name,string newsl) 
        {
            var franchiseId =  companyshortname + "-" + exam_name + "-" + newsl;
            return franchiseId;
        }
     
        public static string MakeStudentId(string newsl)
        {
            if (newsl.Length == 1)
                newsl = "000" + newsl;
            else if (newsl.Length == 2)
                newsl = "00" + newsl;
            else if (newsl.Length == 3)
                newsl = "0" + newsl;
            var studentid= (DateTime.Today.Year.ToString().Substring(DateTime.Today.Year.ToString().Length - 2)) + (DateTime.Today.Month + 7).ToString() + DateTime.Today.Day + newsl;
            return studentid;
        }
        public static double? BalanceCalculation(double amt, string operationType, double previousAmt)
        {

            switch (operationType)
            {
                case SD.Add:
                    previousAmt += amt;
                    break;
                case SD.Substract:
                    previousAmt -= amt; break;
                default:
                    break;
            }
            return previousAmt;
        }
       //public static double? ReceivedAmountCalculation(double? amt, string? operationType, double? charges)
       // {

       //     switch (operationType)
       //     {
       //         case SD.Add:
       //             amt += charges;
       //             break;
       //         case SD.Substract:
       //             amt -= charges; break;
       //         default:
       //             break;
       //     }
       //     return amt;
       // }
        public static string MakeStudentPassword()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkl";
            var nums = "0123456789";
            var stringChars = new char[7];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                if (i < 4) {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                else
                {
                    stringChars[i] = nums[random.Next(nums.Length)];
                }
                
            }
            var stpassword = String.Concat(stringChars);          
            return stpassword;
        }

    }
}
