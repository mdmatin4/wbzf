
using Microsoft.EntityFrameworkCore;
using wbzf.DataAccess.Data;
using wbzf.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace wbzf.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //FoodType,Category
            //_db.ShoppingCart.Include(u => u.MenuItem).ThenInclude(u => u.Category);
            //_db.MenuItem.OrderBy(u => u.Name);
            this.dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, Expression<Func<T, object>>? distinctByExpr = null, string? includeProperties = null, int pageNumber = 0, int pageSize = 0)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            //if (orderby != null)
            //{
            //    query= orderby(query);
            //}
            if (distinctByExpr != null)
            {
                query = query.GroupBy(distinctByExpr).Select(g => g.First());
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (pageNumber > 0 && pageSize > 0)
            {
                // Calculate the number of items to skip based on the page number and page size
                int itemsToSkip = (pageNumber - 1) * pageSize;

                query = query.Skip(itemsToSkip)
                             .Take(pageSize);
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }


        public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>? distinctByExpr = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (distinctByExpr != null)
            {
                query = query.GroupBy(distinctByExpr).Select(g => g.First());

                //var list = query.ToListAsync();
                //return list.Result.Count();
            }
            return await query.CountAsync();

        }

    }
}
