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
    public class AccountGatewaySetupRepository : Repository<AccountGatewaySetup>, IAccountGatewaySetupRepository
    {
        private readonly ApplicationDbContext _db;
        public AccountGatewaySetupRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(AccountGatewaySetup accountSetup)
        {
            var objFromDb = _db.accountGatewaySetups.FirstOrDefault(u => u.Id==accountSetup.Id);
            if (objFromDb!=null)
            {
                if (accountSetup.SecretName!=null)
                {
                    objFromDb.SecretName=accountSetup.SecretName;
                }
                if (accountSetup.secretValue!=null)
                {
                    objFromDb.secretValue=accountSetup.secretValue;
                }
                objFromDb.updated_at=DateTime.Now;
            }

        }
    }
}
