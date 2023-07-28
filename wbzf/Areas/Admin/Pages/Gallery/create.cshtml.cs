using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace wbzf.Areas.Admin.Pages.Gallery
{
    [Authorize(Roles = $"{SD.Admin}")]

    public class createModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
       
        [BindProperty]
        public gallery galleryitem { get; set; }

        public IEnumerable<SelectListItem> DropDownCategories { get; set; }
        public createModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            galleryitem = new();
        }
        public void OnGet(int? id)
        {

            DropDownCategories=_unitOfWork.galleryCategory.GetAll(orderby: m=>m.OrderBy(u=>u.Order)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            if (id != null)
            {
                //Edit
                galleryitem = _unitOfWork.gallery.GetFirstOrDefault(u => u.Id == id);
                
            }

        }
        


        public async Task<IActionResult> OnPost()
        {

            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images/gallery");
            var uploadsthumb = Path.Combine(webRootPath, @"images/thumbnail");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (!Directory.Exists(uploadsthumb))
            {
                Directory.CreateDirectory(uploadsthumb);
            }

            if (galleryitem.Id == 0)
            {
                if (files.Count>0)
                {

                    var extension = Path.GetExtension(files[0].FileName);
                    if (galleryitem.filetypeId == 1)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        galleryitem.ImageUrl = @"/images/gallery/" + fileName_new + extension;
                    }

                    else if (galleryitem.filetypeId == 2)
                    {
                        var extension_forthumbnail = Path.GetExtension(files[0].FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploadsthumb, fileName_new + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        galleryitem.ThumbnailUrl = @"/images/thumbnail/" + fileName_new + extension_forthumbnail;
                    }



                }

                _unitOfWork.gallery.Add(galleryitem);
                _unitOfWork.Save();
            }
            else
            {

                //edit
                var objFromDb = _unitOfWork.gallery.GetFirstOrDefault(u => u.Id == galleryitem.Id);
                if (files.Count > 0)
                {
                    var extension = Path.GetExtension(files[0].FileName);
                    if (objFromDb.filetypeId==1)
                    {
                        //delete the old image
                        if (objFromDb.ImageUrl!=null)
                        {
                            var oldImagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                    }
                    else if (objFromDb.filetypeId==2)
                    {
                        //delete the old thumnail
                        if (objFromDb.ThumbnailUrl!=null)
                        {
                            var oldImagePath = Path.Combine(webRootPath, objFromDb.ThumbnailUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }
                    }

                    if (galleryitem.filetypeId==1)
                    {
                        //new upload
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        galleryitem.ImageUrl = @"/images/gallery/" + fileName_new + extension;
                    }
                    else if (galleryitem.filetypeId==2)
                    {
                        //new upload thumbain
                        using (var fileStream = new FileStream(Path.Combine(uploadsthumb, fileName_new + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        galleryitem.ThumbnailUrl = @"/images/thumbnail/" + fileName_new + extension;
                    }
                }

                _unitOfWork.gallery.update(galleryitem);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
