using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Pages
{
    public class Contact_usModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        public Company company { get; set; }
        [BindProperty]
        public contactform contactform { get; set; }
        public Contact_usModel(IUnitOfWork unitOfWork)
        {
            _unitofWork=unitOfWork;
        }
        public void OnGet()
        {
            company = _unitofWork.company.GetCompany();
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                contactform.Created_at = DateTime.Now;
                contactform.IsRead=false;
                _unitofWork.contactForm.Add(contactform);
                _unitofWork.Save();

            }

        }
    }
}
