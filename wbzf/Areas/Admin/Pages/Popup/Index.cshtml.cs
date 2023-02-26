using wbzf.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Configuration;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.Areas.Admin.Pages.Popup
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private IUnitOfWork _unitofWork;
        private IWebHostEnvironment _hostEnvironment;
        public PopupSet popup { get; set; }
        public IndexModel(IUnitOfWork unitofWork, IWebHostEnvironment hostEnvironment)
        {
            _unitofWork = unitofWork;
            _hostEnvironment = hostEnvironment;
            popup = new();

        }
        public void OnGet()
        {
            popup = _unitofWork.company.GetPopup();

        }

        public async Task<IActionResult> OnPostSubmit()
        {

            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images/popup");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (files.Count > 0)
            {
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                popup.imageLink = @"/images/popup/" + fileName_new + extension;
            }


            _unitofWork.company.updatepopup(popup);
            TempData["success"] = "The Popup status has been updated successfully";
            return RedirectToPage();

        }

    }
}
