using Microsoft.Extensions.Configuration;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        public UnitOfWork(ApplicationDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userMgr)
        {
            _db = db;
            _userManager = userMgr;
            _config=configuration;
            users=new Users(_userManager, _db);
            company = new CompanyConfiguration(_config);
            coachingApplication=new coachingApplicationRepository(_db);
            donation=new DonationRepository(_db);
            scholarshipApplication=new scholarshipApplicationRepository(_db);
            profession=new ProfessionRepository(_db);
            purpose=new PurposeRepository(_db);
            scheme=new SchemeRepository(_db);
            account=new AccountRepository(_db);
            paymentGateway=new PaymentGatewayRepository(_db);
            accountGatewaySetup=new AccountGatewaySetupRepository(_db);
            membersforHome=new MembersforHomeRepository(_db);
            testimonial=new TestimonialRepository(_db);
            newsLink=new NewsLinkRepository(_db);
            quote=new QuoteRepository(_db);
            contactForm=new ContactFormRepository(_db);
            gallery=new galleryRepository(_db);
            galleryCategory=new GalleryCategoryRepository(_db);
            sponsor=new SponsorRepository(_db);
            report=new ReportRepository(_db);
            
            //contact_us = new ContactUsRepository(_db);
        }
        public ICompanyConfiguraion company { get; private set; }
        public IUsers users { get; private set; }
        public IcoachingApplicationRepository coachingApplication { get; private set; }
        public IDonationRepository donation { get; private set; }
        public IScholarshipApplicationRepository scholarshipApplication { get; private set; }
        public IprofessionRepository profession { get; private set; }
        public IPurposeRepository purpose { get; private set; }
        public ISchemeRepository scheme { get; private set; }
        public IAccountRepository account { get; private set; }
        public IPaymentGatewayRepository paymentGateway { get; private set; }
        public IAccountGatewaySetupRepository accountGatewaySetup { get; private set; }
        public IMembersforHomeRepository membersforHome { get; private set; }
        public ITestimonialRepository testimonial { get; private set; }
        public INewsLinkRepository newsLink { get; private set; }
        public IQuoteRepository quote { get; private set; }
        public IContactFormRepository contactForm { get; private set; }
        public IGallery gallery { get; private set; }
        public IGalleryCategoryRepository galleryCategory { get; private set; }
        public ISponsorRepository sponsor { get; private set; }
        public IReportRepository report { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
