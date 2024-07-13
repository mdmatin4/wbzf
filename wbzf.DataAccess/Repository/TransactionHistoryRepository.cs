using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.DataAccess.Repository
{
    public class TransactionHistoryRepository : Repository<TransactionHistory>, ITransactionHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public TransactionHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(TransactionHistory transactionHistory)
        {
            //var objFromDb = _db.Accounts.FirstOrDefault(u => u.Id==account.Id);
            //if (objFromDb!=null)
            //{
            //    objFromDb.Name=account.Name;
            //    objFromDb.Account_no=account.Account_no;
            //    if (account.bankName!=null)
            //    {
            //        objFromDb.bankName=account.bankName;
            //    }
            //    if (account.branchName!=null)
            //    {
            //        objFromDb.branchName=account.branchName;
            //    }
            //    if (account.ifsc!=null)
            //    {
            //        objFromDb.ifsc=account.ifsc;
            //    }
            //    if (account.micr!=null)
            //    {
            //        objFromDb.micr=account.micr;
            //    }
            //    objFromDb.isvisibletoPublic=account.isvisibletoPublic;
            //    objFromDb.updated_at=DateTime.Now;
            //}

        }
        
    }
}
