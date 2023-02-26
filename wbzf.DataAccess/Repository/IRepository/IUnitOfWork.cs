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
        //IContactUsRepository contact_us { get; }
        void Save();
    }
}
