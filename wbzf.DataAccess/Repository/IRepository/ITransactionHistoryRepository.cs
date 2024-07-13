using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface ITransactionHistoryRepository : IRepository<TransactionHistory>
    {
        void update(TransactionHistory transaction);
        //void SoftDelete (Account entity);
    }
}
