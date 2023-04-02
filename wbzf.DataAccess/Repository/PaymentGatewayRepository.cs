using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.DataAccess.Repository
{
    public class PaymentGatewayRepository : Repository<PaymentGateway>, IPaymentGatewayRepository
    {
        private readonly ApplicationDbContext _db;
        public PaymentGatewayRepository(ApplicationDbContext db) : base(db)
        {
            _db=db;
        }

        public void update(PaymentGateway paymentGateway)
        {
            var objFromDb = _db.PaymentGateways.FirstOrDefault(u => u.Id==paymentGateway.Id);
            if (objFromDb!=null)
            {
                objFromDb.Name=paymentGateway.Name;
                objFromDb.is_active=paymentGateway.is_active;
                if (paymentGateway.logo_url!=null)
                {
                    objFromDb.logo_url=paymentGateway.logo_url;
                }
                if (paymentGateway.intro_image_url!=null)
                {
                    objFromDb.intro_image_url=paymentGateway.intro_image_url;
                }
                objFromDb.updated_at=DateTime.Now;
            }

        }
        public void SoftDelete(PaymentGateway entity)
        {
            var objFromDb = _db.PaymentGateways.FirstOrDefault(u => u.Id==entity.Id);
            if (objFromDb!=null)
            {
                objFromDb.is_deleted=true;
                objFromDb.updated_at=DateTime.Now;
            }
        }
        public void SoftRecover (PaymentGateway entity)
        {
            var objFromDb = _db.PaymentGateways.FirstOrDefault(u => u.Id==entity.Id);
            if (objFromDb!=null)
            {
                objFromDb.is_deleted=false;
                objFromDb.updated_at=DateTime.Now;
            }
        }

    }
}
