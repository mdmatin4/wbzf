using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.Model
{
    public class PaymentGateway
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? logo_url { get; set; }
        public string? intro_image_url { get; set; }
        public bool is_active { get; set; }
        public bool is_deleted { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
