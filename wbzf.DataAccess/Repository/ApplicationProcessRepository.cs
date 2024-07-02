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
    public class ApplicationProcessRepository : Repository<ApplicationProcessing>, IApplicationProcessRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationProcessRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void Sanction(ApplicationProcessing applicationProcessing)
        {
            var objFromDb = _db.application_processing.FirstOrDefault(u => u.Id==applicationProcessing.Id);
            if (objFromDb!=null)
            {
                objFromDb.ApproverId=applicationProcessing.ApproverId;
                objFromDb.Approved_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            }

        }
    }
}
