using wbzf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IGalleryCategoryRepository : IRepository<galleryCategory>
    {
        void update(galleryCategory galleryCategory);
    }
}
