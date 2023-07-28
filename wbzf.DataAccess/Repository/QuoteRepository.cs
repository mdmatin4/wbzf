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
    public class QuoteRepository : Repository<quote>, IQuoteRepository
    {
        private readonly ApplicationDbContext _db;
        public QuoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void update(quote quote)
        {
            var objFromDb = _db.quotes.FirstOrDefault(s => s.Id == quote.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = quote.Name;
                objFromDb.statement = quote.statement;
            }
        }
    }
}
