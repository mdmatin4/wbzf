using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace wbzf.Areas.Admin.Pages.Settings
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private IUnitOfWork _unitofWork;
        public Company company { get; set; }
        public Smtp smtp { get; set; }
        public RazorpayConfig rzp { get; set; }
        public IndexModel(IUnitOfWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
            _unitofWork = unitofWork;
            _hostEnvironment = hostEnvironment;
            company = new();
            smtp = new();
            rzp=new();
        }
        public void OnGet()
        {
            company = _unitofWork.company.GetCompany();
            smtp = _unitofWork.company.GetSmtp();
            rzp=_unitofWork.company.GetRazorpay();
        }
        public async Task<IActionResult> OnPostSubmit()
        {
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new;
            var uploads = Path.Combine(webRootPath, @"images/logo");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (files.Count > 0)
            {
                var extension = Path.GetExtension(files[0].FileName);
                fileName_new = Guid.NewGuid().ToString();
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                company.logo = @"/images/logo/" + fileName_new + extension;

              
            }

            _unitofWork.company.updaterazorpay(rzp);
            _unitofWork.company.update(company);
            _unitofWork.company.updatesmtp(smtp);
            TempData["success"] = "The Company details has been updated successfully";
            return RedirectToPage();
        }

    }
}
