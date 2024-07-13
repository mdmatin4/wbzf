using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;

namespace wbzf.Areas.Admin.Pages.Donation
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    public class IndexModel : PageModel
    {
        public IEnumerable<donation> Donations { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public donation donationitem { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public void OnGet()
        {
            Donations=_unitOfWork.donation.GetAll(orderby: u => u.OrderByDescending(m => m.created_at));
        }
        public IActionResult OnPostChangeStat(string id)
        {
            donationitem=_unitOfWork.donation.GetFirstOrDefault(u => u.Id==id);
            donationitem.status=SD.Utilized;
            _unitOfWork.donation.update(donationitem);
            _unitOfWork.Save();
            return Page();
        }
    }
}
