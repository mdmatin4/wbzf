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
    public class ContactFormRepository : Repository<contactform>, IContactFormRepository
    {
        private readonly ApplicationDbContext _db;
        public ContactFormRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }
        public void update(contactform contactform)
        {
            var objFromDb = _db.contactforms.FirstOrDefault(u => u.Id == contactform.Id);
            if (objFromDb != null)
            {
                objFromDb.IsRead= true;
                if(objFromDb.Updated_at ==null)
                {
                    objFromDb.Updated_at= DateTime.Now;
                }
                
            }
        }
    }
}
