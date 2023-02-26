using wbzf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Utility
{
    public interface ICompanyConfiguraion
    {
        Company GetCompany ();
        Smtp GetSmtp();
        PopupSet GetPopup();
        RazorpayConfig GetRazorpay();
        void update(Company company);
        void updatesmtp(Smtp smtp); 
        void updatepopup(PopupSet popup);
        void updaterazorpay(RazorpayConfig razorpayConfig);
    }
}
