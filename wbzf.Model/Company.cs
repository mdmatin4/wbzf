using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace wbzf.Model
{
    public class Company
    {
        //company
        
        public string name { get; set; }
       
        public string email { get; set; }
        [Display(Name = "Mobile No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string mobile { get; set; }
        [Display(Name = "Whatsapp No")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Whatsapp Number.")]
        public string? whatsapp { get; set; }
        public string? support_email { get; set; }
        public string? terms_for_coaching { get; set; }
        public string? coorporate_address { get; set;}
        public string address { get; set; }
        public string? company_short_name { get; set; }

        //social
        public string? fb_link { get; set; }
        public string? youtube_link { get; set;}
        public string? insta_link { get; set; }

        // AboutUs
        public string? taggline { get; set; }
        public string? aboutus_home { get; set; }
        public string? about_us_first_para { get; set; }
        public string? about_us_second_para { get; set; }
       
        //Dmessage
        public string? dmessage_first_para { get; set;}
        public string? dmessage_second_para { get; set; }

        //Privatisation
        public string? extra_text_on_slider { get; set; }
        public string? marquetext { get; set; }
        public string? isotext { get; set; }

        //Query Text
       public string? home_query_form_text { get; set; }

        //Flickr
        public string? flickr_api { get; set; }
        public string? flickr_user { get; set; }
        public string? flickr_album_id { get; set; }

        //SMS Gateway

        public string? smsapi { get; set; }
        public string? sms_name { get; set; }

        //Domain Setup
        public string url { get; set; }
        public string payment_url { get; set; }

        //smtp
        public string? host { get; set; }
        public string? port { get; set; }
        public string? fromEmail { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? logo { get; set; }

      public string? google_location { get; set; }
      public string?  sample_certificate { get; set; }
    }
}
