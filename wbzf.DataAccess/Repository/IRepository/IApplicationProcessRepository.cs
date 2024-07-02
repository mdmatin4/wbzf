using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IApplicationProcessRepository : IRepository<ApplicationProcessing>
    {
        void Sanction(ApplicationProcessing applicationProcessing);
      
    }
}
