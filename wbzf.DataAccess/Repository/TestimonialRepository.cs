using wbzf.Model;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository
{
    public class TestimonialRepository : Repository<testimonial>, ITestimonialRepository
    {
        private readonly ApplicationDbContext _db;
        public TestimonialRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(testimonial testimonial)
        {
            var objFromDb = _db.testimonials.FirstOrDefault(s => s.Id == testimonial.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = testimonial.Name;
                objFromDb.statement = testimonial.statement;
                objFromDb.DisplayOrder=testimonial.DisplayOrder;
                if (testimonial.Designation!=null)
                {
                    objFromDb.Designation=testimonial.Designation;
                }

                if (testimonial.ImageUrl!=null)
                {
                    objFromDb.ImageUrl=testimonial.ImageUrl;
                }
            }
        }
    }
}
