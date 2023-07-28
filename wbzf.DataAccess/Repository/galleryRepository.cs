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
    public class galleryRepository : Repository<gallery>, IGallery
    {
        private readonly ApplicationDbContext _db;
        
        public galleryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(gallery gallery)
        {
            var objFromDb = _db.gallery.FirstOrDefault(u => u.Id == gallery.Id);
            if (objFromDb != null)
            {
                objFromDb.filetypeId = gallery.filetypeId;
                objFromDb.CategoryId=gallery.CategoryId;
                if(gallery.VideoUrl != null)
                {
                    objFromDb.VideoUrl = gallery.VideoUrl;
                }
                if(gallery.Title != null)
                {
                    objFromDb.Title = gallery.Title;
                }
                if (gallery.Description!=null)
                {
                    objFromDb.Description = gallery.Description;  
                }
                if(gallery.ImageUrl!= null)
                {
                    objFromDb.ImageUrl=gallery.ImageUrl;
                }
                if(gallery.ThumbnailUrl!= null)
                {
                    objFromDb.ThumbnailUrl=gallery.ThumbnailUrl;
                }
                objFromDb.updatedat=gallery.updatedat;
            }
        }
    }
}
