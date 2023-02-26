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
    public class scholarshipApplicationRepository : Repository<ScholarshipApplication>, IScholarshipApplicationRepository
    {
        private readonly ApplicationDbContext _db;
        public scholarshipApplicationRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }


        public void update(ScholarshipApplication application)
        {
            var objFromDb = _db.coachingForms.FirstOrDefault(u => u.Id==application.Id);
            if (objFromDb!=null)
            {
            }
        }
    }
}
