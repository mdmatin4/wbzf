using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.Testimonial
{
    [Authorize(Roles = $"{SD.Admin}")]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public testimonial testimonial { get; set; }


        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            testimonial = new();
        }
        public void OnGet(int? id)
        {
            if (id!=null)
            {
                testimonial=_unitOfWork.testimonial.GetFirstOrDefault(u => u.Id==id);
            }

        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images/Testimonial");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (ModelState.IsValid)
            {
                
                if (testimonial.Id==0)
                {
                    if (files.Count>0)
                    {
                        var extension = Path.GetExtension(files[0].FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        testimonial.ImageUrl = @"/images/Testimonial/" + fileName_new + extension;
                    }
                    _unitOfWork.testimonial.Add(testimonial);
                    _unitOfWork.Save();
                    TempData["success"] = "Testimonial created successfully";
                }
                else
                {
                    var objFromDb = _unitOfWork.testimonial.GetFirstOrDefault(u => u.Id == testimonial.Id);
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
                        testimonial.ImageUrl = @"/images/Testimonial/" + fileName_new + extension;
                    }
                    _unitOfWork.testimonial.update(testimonial);
                    _unitOfWork.Save();
                    TempData["success"] = "Testimonial Updated successfully";
                }
                return RedirectToPage("Index");

            }
            return Page();
        }
    }
}
