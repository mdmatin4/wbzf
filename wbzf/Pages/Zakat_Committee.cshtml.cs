using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Pages
{
    public class Zakat_CommitteeModel : PageModel
    {
        public string[] userType = new string[] { SD.OurTeamMembers, SD.OurAdvisoryCommitte, SD.OurAuditor, SD.OurLegalExpert, SD.OurMufti, SD.OurMembers };
        private IUnitOfWork _unitofWork;
        public IEnumerable<MembersforHome> membersList;

        public Zakat_CommitteeModel(IUnitOfWork unitOfWork)
        {
            _unitofWork=unitOfWork;
        }
        public void OnGet()
        {
            membersList=_unitofWork.membersforHome.GetAll(orderby: o => o.OrderBy(m => m.displayOrder));
        }
    }
}
