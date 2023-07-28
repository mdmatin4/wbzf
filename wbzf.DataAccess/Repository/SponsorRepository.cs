using wbzf.Model;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository
{
    public class SponsorRepository : Repository<Sponsor>,ISponsorRepository
    {
        private readonly ApplicationDbContext _db;
        public SponsorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Sponsor sponsor)
        {
            var objFromDb = _db.sponsors.FirstOrDefault(s => s.Id == sponsor.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = sponsor.Title;
                if (sponsor.Website!=null)
                {
                    objFromDb.Website = sponsor.Website;
                }
                objFromDb.displayOrder=sponsor.displayOrder;

                if (sponsor.ImageUrl != null)
                {
                    objFromDb.ImageUrl = sponsor.ImageUrl;
                }
            }
        }
    }
}
