using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.Model;

namespace wbzf.DataAccess.Repository.IRepository
{
    public interface IprofessionRepository: IRepository<Profession>
    {
        void update(Profession entity);
        IEnumerable<SelectListItem> getProfessionforSelectItem();
    }
}
