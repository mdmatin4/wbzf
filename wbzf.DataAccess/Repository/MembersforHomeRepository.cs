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
    public class MembersforHomeRepository : Repository<MembersforHome>, IMembersforHomeRepository
    {
        private readonly ApplicationDbContext _db;
       
        public MembersforHomeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(MembersforHome members)
        {
            var objFromDb = _db.membersforHome.FirstOrDefault(s => s.Id == members.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = members.Name;
                objFromDb.displayOrder = members.displayOrder;
                objFromDb.role = members.role;
                if (members.ImageUrl != null)
                {
                    objFromDb.ImageUrl = members.ImageUrl;
                }
            }
        }
    }
}
