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
    public class DonationRepository : Repository<donation>, IDonationRepository
    {
        private readonly ApplicationDbContext _db;
        public DonationRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(donation donation)
        {
            var objFromDb = _db.donations.FirstOrDefault(u => u.Id==donation.Id);
            if (objFromDb!=null)
            {
            }

        }
    }
}
