using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.DataAccess.Repository
{
    public class MainAccountRepository : Repository<MainAc>, IMainAccountRepository
    {
        private readonly ApplicationDbContext _db;
        public MainAccountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void updateBalance(string transaction_type, string transaction_id)
        {
            var transaction = _db.Transaction_History.FirstOrDefault(u => u.Id == transaction_id);
            var mainAccountEntryAgainstThisTransaction = _db.main_Account.FirstOrDefault(u => u.Transaction_Id == transaction_id);
            if (transaction != null && transaction.Payment_Status == SD.Success && mainAccountEntryAgainstThisTransaction == null)
            {
                TransactionMainAccountEntry(transaction, transaction_type, transaction.Account_Id);
                if (transaction.ToAccount_Id != null)
                {
                    if (transaction_type == SD.Add)
                    {
                        transaction_type = SD.Substract;
                        transaction.received_amount = transaction.Amount + transaction.transaction_fees.Value;
                    }
                    else if (transaction_type == SD.Substract)
                    {
                        transaction_type = SD.Add;
                        transaction.received_amount = transaction.Amount;
                    }
                    TransactionMainAccountEntry(transaction, transaction_type, transaction.ToAccount_Id.Value);
                }

            }

        }
        private void TransactionMainAccountEntry(TransactionHistory transaction, string TransactionType, int accountId)
        {
            double? newBalance = 0;
            var LastTransaction = _db.main_Account.OrderByDescending(u => u.Created_at).FirstOrDefault(u => u.Account_Id == accountId);
            LastTransaction.Bal = LastTransaction?.Bal ?? 0;
            transaction.transaction_fees = transaction.transaction_fees ?? 0;
            if (TransactionType == SD.Add)
            {
                newBalance = Formula.BalanceCalculation(transaction.received_amount, TransactionType, LastTransaction.Bal);
            }
            else if(TransactionType == SD.Substract)
            {
                newBalance = Formula.BalanceCalculation((transaction.Amount+transaction.transaction_fees.Value), TransactionType, LastTransaction.Bal);
            }

            _db.main_Account.Add(new MainAc()
            {
                Account_Id = accountId,
                Transaction_Id = transaction.Id,
                Cr = TransactionType == SD.Add ? transaction.received_amount : 0,
                Dr = TransactionType == SD.Substract ? (transaction.Amount+transaction.transaction_fees.Value) : 0,
                Bal = newBalance.Value,
                Created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30)
            });
        }
        //public void SoftDelete(Account entity)
        //{
        //    var objFromDb = _db.Accounts.FirstOrDefault(u => u.Id == entity.Id);
        //    if (objFromDb != null)
        //    {
        //        objFromDb.is_deleted = true;
        //        objFromDb.updated_at = DateTime.Now;
        //    }
        //}
    }
}
