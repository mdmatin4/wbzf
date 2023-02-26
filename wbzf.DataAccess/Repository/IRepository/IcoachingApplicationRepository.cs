using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IcoachingApplicationRepository : IRepository<coachingForm>
    {
        void update(coachingForm coachingForm);
        void UpdateStatus (coachingForm coachingForm);
    }
}
