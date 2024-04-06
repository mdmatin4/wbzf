using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Settings
{
    public class ProfessionsModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        [BindProperty]
        public Profession profession { get; set; }
        public IEnumerable<Profession> ProfessionList { get; set; }
        public ProfessionsModel(IUnitOfWork unitOfWork)
        {
            profession=new Profession()
            {
                IsActive = true,
            };
            _unitofWork=unitOfWork;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                profession = _unitofWork.profession.GetFirstOrDefault(u => u.Id == id);
            }
            ProfessionList= _unitofWork.profession.GetAll();
        }
        
        public IActionResult OnPost()
        {
            if (profession.Id==0)
            {
                profession.Created_at = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                profession.IsActive = true;

                _unitofWork.profession.Add(profession);
                _unitofWork.Save();
                TempData["success"] = "This Profession added successfully";

            }
            else
            {
                _unitofWork.profession.update(profession);
                _unitofWork.Save();
                TempData["success"] = "This Profession updated successfully";
            }

            return RedirectToPage();

        }
        
        public IActionResult OnPostDelete(int id)
        {
            _unitofWork.profession.Remove(profession);
            _unitofWork.Save();
            TempData["delete"] = "This Profession is Permanatly deleted.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostEdit(int id)
        {
            return RedirectToPage(new { id = id });
        }
    }
}
