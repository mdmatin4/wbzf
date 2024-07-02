using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{

    public interface IApplicationRegisterRepository : IRepository<ApplicationRegister>
    {
        void update(ApplicationRegister appReg);
        void Sanction(ApplicationRegister appReg);
        void Verify(ApplicationRegister appReg);
        void updation(ApplicationRegister appReg);

    }
}
