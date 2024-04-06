using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IPurposeRepository : IRepository<Purpose>
    {
        void update(Purpose entity);
        void Deactive (Purpose entity);
        void Activate(Purpose entity);
        void updatestatus(int id);

    }
}
