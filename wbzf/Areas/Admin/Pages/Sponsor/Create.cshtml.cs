using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Sponsor
{
    [Authorize(Roles = $"{SD.Admin}")]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public wbzf.Model.Sponsor sponsor { get; set; }
        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            sponsor = new();
        }
        public void OnGet(int? id)
        {


            if (id != null)
            {
                //Edit
                sponsor = _unitOfWork.sponsor.GetFirstOrDefault(u => u.Id == id);
            }

        }

        public async Task<IActionResult> OnPost()
        {

            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images/News");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (sponsor.Id == 0)
            {
                if (files.Count>0)
                {
                    var extension = Path.GetExtension(files[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    sponsor.ImageUrl = @"/images/News/" + fileName_new + extension;
                }

                _unitOfWork.sponsor.Add(sponsor);
                _unitOfWork.Save();
            }
            else
            {

                //edit
                var objFromDb = _unitOfWork.sponsor.GetFirstOrDefault(u => u.Id == sponsor.Id);
                if (files.Count > 0)
                {
                    var extension = Path.GetExtension(files[0].FileName);
                    //delete the old image
                    if (objFromDb.ImageUrl!=null)
                    {
                        var oldImagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }


                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    sponsor.ImageUrl = @"/images/News/" + fileName_new + extension;
                }

                _unitOfWork.sponsor.update(sponsor);
                _unitOfWork.Save();
                TempData["success"] = "Sponsor Updated successfully";
            }

            return RedirectToPage("./Index");
        }
    }
}
