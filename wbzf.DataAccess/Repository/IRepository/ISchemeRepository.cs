using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface ISchemeRepository : IRepository<Scheme>
    {
        void update(Scheme entity);
        void Deactive(Scheme entity);
        void Activate(Scheme entity);
    }
}
