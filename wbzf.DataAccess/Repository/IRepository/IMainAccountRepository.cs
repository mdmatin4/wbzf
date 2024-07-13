using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IMainAccountRepository : IRepository<MainAc>
    {
         void updateBalance(string transaction_type, string transaction_id);
        //void SoftDelete (Account entity);
    }
}
