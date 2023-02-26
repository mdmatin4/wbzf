using wbzf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Configuration;

namespace wbzf.Utility
{
    public class CompanyConfiguration : ICompanyConfiguraion
    {
        private IConfiguration _config;

        public CompanyConfiguration(IConfiguration config)
        {
            _config = config;
        }

        public Company GetCompany()
        {
            Company company = new Company();
            ConfigurationBinder.Bind(_config, "Company", company);
            return company;
        }
        public Smtp GetSmtp()
        {
            Smtp smtp = new Smtp();
            ConfigurationBinder.Bind(_config, "Smtp", smtp);
            return smtp;
        }

        public RazorpayConfig GetRazorpay()
        {
            RazorpayConfig razorpay = new RazorpayConfig();
            ConfigurationBinder.Bind(_config, "Razorpay", razorpay);
            return razorpay;
        }
        public PopupSet GetPopup()
        {
            PopupSet popup = new PopupSet();
            ConfigurationBinder.Bind(_config, "Popup", popup);
            return popup;
        }
        public void update(Company company)
        {
            var settingsUpdater = new AppSettingsUpdater();
            if (company.name != null)
            {
                settingsUpdater.UpdateAppSetting("Company:name", company.name);
            }
            if (company.company_short_name != null)
            {
                settingsUpdater.UpdateAppSetting("Company:company_short_name", company.company_short_name);
            }
            if (company.logo != null)
            {
                settingsUpdater.UpdateAppSetting("Company:logo", company.logo);
            }
            if (company.mobile != null)
            {
                settingsUpdater.UpdateAppSetting("Company:mobile", company.mobile);
            }
            if (company.email != null)
            {
                settingsUpdater.UpdateAppSetting("Company:email", company.email);
            }
            if (company.whatsapp != null)
            {
                settingsUpdater.UpdateAppSetting("Company:whatsapp", company.whatsapp);
            }
            if (company.support_email != null)
            {
                settingsUpdater.UpdateAppSetting("Company:support_email", company.support_email);
            }
            if (company.address != null)
            {
                settingsUpdater.UpdateAppSetting("Company:address", company.address);
            }
            if (company.coorporate_address != null)
            {
                settingsUpdater.UpdateAppSetting("Company:coorporate_address", company.coorporate_address);
            }
            if (company.aboutus_home != null)
            {
                settingsUpdater.UpdateAppSetting("Company:aboutus_home", company.aboutus_home);
            }
            if (company.about_us_first_para != null)
            {
                settingsUpdater.UpdateAppSetting("Company:about_us_first_para", company.about_us_first_para);
            }
            if (company.about_us_second_para != null)
            {
                settingsUpdater.UpdateAppSetting("Company:about_us_second_para", company.about_us_second_para);
            }
            if (company.taggline != null)
            {
                settingsUpdater.UpdateAppSetting("Company:taggline", company.taggline);
            }
            if (company.dmessage_first_para != null)
            {
                settingsUpdater.UpdateAppSetting("Company:dmessage_first_para", company.dmessage_first_para);
            }
            if (company.dmessage_second_para != null)
            {
                settingsUpdater.UpdateAppSetting("Company:dmessage_second_para", company.dmessage_second_para);
            }
            if (company.home_query_form_text != null)
            {
                settingsUpdater.UpdateAppSetting("Company:home_query_form_text", company.home_query_form_text);
            }
            if (company.extra_text_on_slider != null)
            {
                settingsUpdater.UpdateAppSetting("Company:extra_text_on_slider", company.extra_text_on_slider);
            }
            if (company.isotext != null)
            {
                settingsUpdater.UpdateAppSetting("Company:isotext", company.isotext);
            }
            if (company.marquetext != null)
            {
                settingsUpdater.UpdateAppSetting("Company:marquetext", company.marquetext);
            }
            if (company.url != null)
            {
                settingsUpdater.UpdateAppSetting("Company:url", company.url);
            }
            if (company.sms_name != null)
            {
                settingsUpdater.UpdateAppSetting("Company:sms_name", company.sms_name);
            }
            if (company.smsapi != null)
            {
                settingsUpdater.UpdateAppSetting("Company:smsapi", company.smsapi);
            }

            if (company.fb_link != null)
            {
                settingsUpdater.UpdateAppSetting("Company:fb_link", company.fb_link);
            }
            if (company.youtube_link != null)
            {
                settingsUpdater.UpdateAppSetting("Company:youtube_link", company.youtube_link);
            }
            if (company.insta_link != null)
            {
                settingsUpdater.UpdateAppSetting("Company:insta_link", company.insta_link);
            }
            if (company.flickr_user != null)
            {
                settingsUpdater.UpdateAppSetting("Company:flickr_user", company.flickr_user);
            }
            if (company.flickr_api != null)
            {
                settingsUpdater.UpdateAppSetting("Company:flickr_api", company.flickr_api);
            }
            if (company.flickr_album_id != null)
            {
                settingsUpdater.UpdateAppSetting("Company:flickr_album_id", company.flickr_album_id);
            }
             if (company.google_location != null)
            {
                settingsUpdater.UpdateAppSetting("Company:google_location", company.google_location);
            }
              if (company.sample_certificate != null)
            {
                settingsUpdater.UpdateAppSetting("Company:sample_certificate", company.sample_certificate);
            }

        }

        public void updatesmtp(Smtp smtp)
        {
            var settingsUpdater = new AppSettingsUpdater();
            if (smtp.host != null)
            {
                settingsUpdater.UpdateAppSetting("Smtp:host", smtp.host);
            }
            if (smtp.port != null)
            {
                settingsUpdater.UpdateAppSetting("Smtp:port", smtp.port);
            }
            if (smtp.fromEmail != null)
            {
                settingsUpdater.UpdateAppSetting("Smtp:fromEmail", smtp.fromEmail);
            }
            if (smtp.username != null)
            {
                settingsUpdater.UpdateAppSetting("Smtp:username", smtp.username);
            }
            if (smtp.password != null)
            {
                settingsUpdater.UpdateAppSetting("Smtp:password", smtp.password);
            }

        }
        
        public void updatepopup(PopupSet popup)
        {
            var settingsUpdater = new AppSettingsUpdater();

            settingsUpdater.UpdateAppSetting("Popup:enable", popup.enable);

            if (popup.link != null)
            {
                settingsUpdater.UpdateAppSetting("Popup:link", popup.link);
            }
            if (popup.imageLink != null)
            {
                settingsUpdater.UpdateAppSetting("Popup:imageLink", popup.imageLink);
            }


        }
        public void updaterazorpay(RazorpayConfig razorpayConfig)
        {
            var settingsUpdater = new AppSettingsUpdater();
            if (razorpayConfig.key_id!=null)
            {
                settingsUpdater.UpdateAppSetting("Razorpay:key_id", razorpayConfig.key_id);
            }
            if (razorpayConfig.key_secret!=null)
            {
                settingsUpdater.UpdateAppSetting("Razorpay:key_secret", razorpayConfig.key_secret);
            }
        }
    }
}
