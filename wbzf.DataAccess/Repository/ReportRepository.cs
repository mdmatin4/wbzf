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
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        private readonly ApplicationDbContext _db;
        public ReportRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Report report)
        {
            var objFromDb = _db.reports.FirstOrDefault(s => s.Id == report.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = report.Name;
                if (report.description!= null)
                {
                    objFromDb.description= report.description;
                }
                objFromDb.reportType = report.reportType;
                if(report.displayOrder!= null)
                {
                    objFromDb.displayOrder = report.displayOrder;
                }
                if (report.fileUrl != null)
                {
                    objFromDb.fileUrl = report.fileUrl;
                }
                objFromDb.updated_at=DateTime.Now;
            }
        }
    }
}
