using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ProfessionRepository : Repository<Profession>, IprofessionRepository
    {
        private readonly ApplicationDbContext _db;
        public ProfessionRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(Profession profession)
        {
            var objFromDb = _db.professions.FirstOrDefault(u => u.Id==profession.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name=profession.Name;
                objFromDb.IsActive=profession.IsActive;
                objFromDb.updated_at=DateTime.Now;
            }

        }
        public IEnumerable<SelectListItem> getProfessionforSelectItem()
        {
            var list = _db.professions.ToList().Where(u => u.IsActive==true).OrderBy(u => u.Order).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return list;
        }
    }
}
