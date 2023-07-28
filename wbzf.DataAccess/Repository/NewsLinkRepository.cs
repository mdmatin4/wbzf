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
    public class NewsLinkRepository : Repository<newslink>,INewsLinkRepository
    {
        private readonly ApplicationDbContext _db;
        public NewsLinkRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(newslink newslink)
        {
            var objFromDb = _db.newslinks.FirstOrDefault(s => s.Id == newslink.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = newslink.Title;
                objFromDb.publish_date=newslink.publish_date;
                objFromDb.NewsOrganizationName= newslink.NewsOrganizationName;
                objFromDb.NewsLink=newslink.NewsLink;
                objFromDb.displayOrder=newslink.displayOrder;
                if (newslink.ImageUrl != null)
                {
                    objFromDb.ImageUrl = newslink.ImageUrl;
                }
            }
        }
    }
}
