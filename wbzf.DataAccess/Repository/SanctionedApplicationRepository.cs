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
    public class SanctionedApplicationRepository : Repository<SanctionedApplication>, ISanctionedApplicationRepository
    {
        private readonly ApplicationDbContext _db;
        public SanctionedApplicationRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void Update(SanctionedApplication sanctionedApplication)
        {
            var objFromDb = _db.Sanctioned_Application.FirstOrDefault(u => u.Id==sanctionedApplication.Id);
            if (objFromDb!=null)
            {
                objFromDb.Paid_Amount=sanctionedApplication.Paid_Amount;
                objFromDb.Payment_Status=sanctionedApplication.Payment_Status;
                objFromDb.Updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            }

        }
    }
}
