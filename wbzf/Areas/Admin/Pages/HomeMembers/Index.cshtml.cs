using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.HomeMembers
{
    [Authorize(Roles = $"{SD.Admin}")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public string usertype { get; set; }
        public IEnumerable<MembersforHome> members { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            string membertype;
            var members = _unitOfWork.membersforHome.GetFirstOrDefault(u => u.Id==id);
            if (members == null)
            {
                return NotFound();

            }
            membertype=members.role;
            _unitOfWork.membersforHome.Remove(members);
            _unitOfWork.Save();

            return RedirectToPage(new {type=membertype});
        }
        public void OnGet(string type)
        {
            if (type==SD.OurTeamMembers)
            {
                usertype=SD.OurTeamMembers;
            }
            else if (type==SD.OurAdvisoryCommitte)
            {
                usertype = SD.OurAdvisoryCommitte;
            }
            else if (type==SD.OurLegalExpert)
            {
                usertype = SD.OurLegalExpert;
            }
            else if (type==SD.OurAuditor)
            {
                usertype = SD.OurAuditor;
            }
            else if (type==SD.OurMufti)
            {
                usertype = SD.OurMufti;
            }
            else if (type==SD.OurMembers)
            {
                usertype = SD.OurMembers;
            }
            
            members = _unitOfWork.membersforHome.GetAll(m=>m.role==usertype,orderby: u => u.OrderBy(c => c.displayOrder));
        }
    }

}
