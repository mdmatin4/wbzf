using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? description { get; set; }
        public string fileUrl { get; set; }
        public string reportType { get; set; }
        public int? displayOrder { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
