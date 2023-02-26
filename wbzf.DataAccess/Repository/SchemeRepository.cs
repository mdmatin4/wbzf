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
    public class SchemeRepository : Repository<Scheme>, ISchemeRepository
    {
        private readonly ApplicationDbContext _db;
        public SchemeRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(Scheme profession)
        {
            var objFromDb = _db.Schemes.FirstOrDefault(u => u.Id==profession.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name=profession.Name;
                objFromDb.IsActive=profession.IsActive;
                objFromDb.updated_at=DateTime.Now;
            }

        }
        public void Deactive(Scheme scheme)
        {
            var objFromDb = _db.Schemes.FirstOrDefault(u => u.Id==scheme.Id);
            if (objFromDb!=null)
            {
                objFromDb.IsActive=false;
                objFromDb.updated_at=DateTime.Now;
            }
        }
        public void Activate(Scheme scheme)
        {
            var objFromDb = _db.Schemes.FirstOrDefault(u => u.Id==scheme.Id);
            if (objFromDb!=null)
            {
                objFromDb.IsActive=false;
                objFromDb.updated_at=DateTime.Now;
            }
        }

       
    }
}
