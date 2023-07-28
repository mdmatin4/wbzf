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
    public class GalleryCategoryRepository : Repository<galleryCategory>, IGalleryCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public GalleryCategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(galleryCategory galleryCategory)
        {
            var objFromDb = _db.galleryCategories.FirstOrDefault(s => s.Id == galleryCategory.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = galleryCategory.Name;
                if(galleryCategory.Order != null)
                {
                    objFromDb.Order = galleryCategory.Order;
                }
                objFromDb.Updated_at = DateTime.Now;
            }
        }
    }
}
