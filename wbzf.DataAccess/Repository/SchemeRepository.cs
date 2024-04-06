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

        public void update(Scheme scheme)
        {
            var objFromDb = _db.Schemes.FirstOrDefault(u => u.Id==scheme.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name=scheme.Name;
                if (scheme.Description!=null)
                {
                    objFromDb.Description=objFromDb.Description;
                }
                objFromDb.IsStartEndVisible=scheme.IsStartEndVisible;
                if (scheme.StartDate!=null)
                {
                    objFromDb.StartDate=scheme.StartDate;
                }
                if (scheme.EndDate!=null)
                {
                    objFromDb.EndDate=scheme.EndDate;
                }
                if (scheme.Eligibility!=null)
                {
                    objFromDb.Eligibility=scheme.Eligibility;
                }
                if (scheme.Form_Url!=null)
                {
                    objFromDb.Form_Url=scheme.Form_Url;
                }
               if (scheme.Image_Url!=null)
                {
                    objFromDb.Image_Url=scheme.Image_Url;
                }
                objFromDb.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            }

        }
        public void Deactive(int id)
        {
            var objFromDb = _db.Schemes.FirstOrDefault(u => u.Id==id);
            if (objFromDb!=null)
            {
                objFromDb.IsActive=false;
                objFromDb.updated_at= DateTime.UtcNow.AddHours(5).AddMinutes(30);
            }
        }
        public void Activate(int id)
        {
            var objFromDb = _db.Schemes.FirstOrDefault(u => u.Id==id);
            if (objFromDb!=null)
            {
                objFromDb.IsActive=true;
                objFromDb.updated_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            }
        }

       
    }
}
