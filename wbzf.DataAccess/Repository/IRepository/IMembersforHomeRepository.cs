using wbzf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IMembersforHomeRepository : IRepository <MembersforHome>
    {
        void update(MembersforHome members);
    }
}
