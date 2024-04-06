using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using wbzf.DataAccess.Repository;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using wbzf.Utility;

namespace wbzf.Areas.Admin.Pages.Schemes
{
    [Authorize(Roles = $"{SD.Admin},{SD.Manager}")]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;
        public Scheme scheme { get; set; }
        public IEnumerable<SelectListItem> purposes { get; set; }


        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            scheme = new();
            _hostEnvironment = hostEnvironment;
        }
        public void OnGet(int? id)
        {
            purposes=_unitOfWork.purpose.GetAll(u => u.IsActive==true, orderby: u => u.OrderBy(m => m.Order)).Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
                Selected = i.IsDefault
            });
            if (id!=null)
            {
                scheme=_unitOfWork.scheme.GetFirstOrDefault(u => u.Id==id);
               
            }

        }
       
        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images/Scheme");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }



            if (ModelState.IsValid)
            {
                if (scheme.Id==0)
                {
                    if (files.Count > 0)
                    {
                        var extension = Path.GetExtension(files[0].FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        scheme.Image_Url = @"\images\Scheme\" + fileName_new + extension;

                    }
                    scheme.IsActive=true;
                    scheme.Created_at= DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    _unitOfWork.scheme.Add(scheme);
                    _unitOfWork.Save();
                    TempData["success"] = "Scheme created successfully";
                }
                else
                {
                    //edit
                    var objFromDb = _unitOfWork.scheme.GetFirstOrDefault(u => u.Id == scheme.Id);
                    if (files.Count > 0)
                    {
                        var extension = Path.GetExtension(files[0].FileName);
                        //delete the old image
                        if (objFromDb.Image_Url != null)
                        {
                            var oldImagePath = Path.Combine(webRootPath, objFromDb.Image_Url.TrimStart('\\'));
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
                        scheme.Image_Url = @"\images\Scheme\" + fileName_new + extension;
                    }
                    else
                    {
                        scheme.Image_Url = objFromDb.Image_Url;
                    }

                    _unitOfWork.scheme.update(scheme);
                    _unitOfWork.Save();
                    TempData["success"] = "Scheme Updated successfully";
                }
                return RedirectToPage("/Schemes/Index");

            }
            return Page();
        }
    }
}
