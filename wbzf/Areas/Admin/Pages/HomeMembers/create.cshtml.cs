using wbzf.Model;
using wbzf.Utility;
using wbzf.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wbzf.Areas.Admin.Pages.HomeMembers
{
    [Authorize(Roles = $"{SD.Admin}")]
    [BindProperties]
    public class createModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MembersforHome member { get; set; }
        public string usertype { get; set; }
        public createModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            member = new();
        }
        public void OnGet(int? id,string type)
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


            if (id != null)
            {
                //Edit
                member = _unitOfWork.membersforHome.GetFirstOrDefault(u => u.Id == id);
            }
            else
            {
                member.role=usertype;
            }
            

        }

        public async Task<IActionResult> OnPost()
        {

            string webRootPath = _hostEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;
            //create
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\Member");

            //post.CategoryId=int.Parse(Request.Form[""]);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (member.Id == 0)
            {
                if (files.Count>0)
                {
                    var extension = Path.GetExtension(files[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    member.ImageUrl = @"\images\Member\" + fileName_new + extension;
                }

                _unitOfWork.membersforHome.Add(member);
                _unitOfWork.Save();
            }
            else
            {

                //edit
                var objFromDb = _unitOfWork.membersforHome.GetFirstOrDefault(u => u.Id == member.Id);
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
                    member.ImageUrl = @"\images\Member\" + fileName_new + extension;
                }
                else
                {
                    member.ImageUrl = objFromDb.ImageUrl;
                }
                _unitOfWork.membersforHome.update(member);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index",new {type=member.role});
        }
    }
}
