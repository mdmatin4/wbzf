using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Utility;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUsers users { get; }
        ICompanyConfiguraion company { get; }
        IcoachingApplicationRepository coachingApplication { get; }
        IDonationRepository donation { get; }
        IScholarshipApplicationRepository scholarshipApplication { get; }
        IprofessionRepository profession { get; }
        IPurposeRepository purpose { get; }
        ISchemeRepository scheme { get; }
        IPaymentGatewayRepository paymentGateway { get; }
        IAccountRepository account { get; }
        IAccountGatewaySetupRepository accountGatewaySetup { get; }
        IGallery gallery { get; }
        IGalleryCategoryRepository galleryCategory { get;}
        IMembersforHomeRepository membersforHome { get; }
        ITestimonialRepository testimonial { get; }
        INewsLinkRepository newsLink { get; }
        IQuoteRepository quote { get; }
        IContactFormRepository contactForm { get; }
        ISponsorRepository sponsor { get; }
        IReportRepository report { get; }

        void Save();
    }
}
