using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.DataAccess.Repository
{
    public class coachingApplicationRepository :  Repository<coachingForm>, IcoachingApplicationRepository
    {
        private readonly ApplicationDbContext _db;
        public coachingApplicationRepository(ApplicationDbContext db): base(db)
        {
            _db=db;
        }

        public void update(coachingForm coachingForm)
        {
            var objFromDb=_db.coachingForms.FirstOrDefault(u=>u.Id==coachingForm.Id);
            if (objFromDb!=null)
            {
            }
        }
        public void UpdateStatus(coachingForm coachingForm)
        {
            var objFromDb = _db.coachingForms.FirstOrDefault(u => u.Id==coachingForm.Id);
            if (objFromDb!=null)
            {
                objFromDb.status=coachingForm.status;
                objFromDb.updated_at=DateTime.Now;
            }
        }
    }
}
