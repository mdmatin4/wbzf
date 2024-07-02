using wbzf.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace wbzf.viewComponents
{
    public class AccountStatementViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IUnitOfWork _unitOfWork, int pageIndex, int pageSize, string? sortColumn, string? sortDirection, string? searchTerm, DateTime? fromDate, DateTime? toDate, int? accountId)
        {
            var isDescending = sortDirection?.ToLower() == "desc";


            // var filterExpression = MultiColumnSearch(searchTerm, txndate, userid);
            var applications = _unitOfWork.mainAccount.GetAll(orderby: BuildOrderByExpression(sortColumn, isDescending),
                filter: MultiColumnSearch(searchTerm, fromDate, toDate, accountId),
                pageNumber: pageIndex,
                pageSize: pageSize, includeProperties: "Accounts").ToList();

            var totalCount = await _unitOfWork.mainAccount.GetCountAsync(filter: MultiColumnSearch(searchTerm, fromDate, toDate, accountId));

            var vmodel = PaginatedList<MainAc>.Create(applications, totalCount, pageIndex, pageSize);

            return View(vmodel);
        }

        private Expression<Func<MainAc, bool>> MultiColumnSearch(string? searchTerm, DateTime? fromDate, DateTime? toDate, int? accountId)
        {
            // Make the search case-insensitive
            // Convert the search term to lowercase

            Expression<Func<MainAc, bool>> filter = null;
            Expression<Func<MainAc, bool>> filter2 = null;
            Expression<Func<MainAc, bool>> filter3 = null;

            if (searchTerm?.Length > 0)
            {

                searchTerm = searchTerm.ToLower();

                filter = c =>
                    c.Accounts.Name.ToLower().Contains(searchTerm)
                    || c.Accounts.Account_no.ToLower().Contains(searchTerm)
                    || c.Transaction_Id.ToLower().Contains(searchTerm)
                    || c.Cr.ToString().Contains(searchTerm)
                    || c.Dr.ToString().Contains(searchTerm)
                    || c.Bal.ToString().Contains(searchTerm)
                    || c.Created_at.ToString().Contains(searchTerm);

            }
            
            if (accountId != null)
            {
                filter2 = c => c.Account_Id == accountId;
                if (filter != null)
                {
                    filter = Expression.Lambda<Func<MainAc, bool>>(
                    Expression.AndAlso(filter.Body, new ExpressionParameterReplacer(filter2.Parameters, filter.Parameters).Visit(filter2.Body)),
                    filter.Parameters[0]);
                }
                else
                {
                    filter = filter2;
                }
            }
           
            if (fromDate != null && toDate != null)
            {
                filter3 = c => c.Created_at >= fromDate && c.Created_at < toDate.Value.AddDays(1);

                if (filter != null)
                {
                    filter = Expression.Lambda<Func<MainAc, bool>>(
                    Expression.AndAlso(filter.Body, new ExpressionParameterReplacer(filter3.Parameters, filter.Parameters).Visit(filter3.Body)),
                    filter.Parameters[0]);
                }
                else
                {
                    filter = filter3;
                }

            }

            return filter;

        }



        private Func<IQueryable<MainAc>, IOrderedQueryable<MainAc>> BuildOrderByExpression(string sortColumn, bool isDescending)
        {
            Func<IQueryable<MainAc>, IOrderedQueryable<MainAc>> orderBy = null;

            switch (sortColumn?.ToLower())
            {
                default:
                    orderBy = cases => cases.OrderByDescending(c => c.Created_at);
                    // Set a default sorting order here if needed
                    break;

            }

            return orderBy;
        }

    }
}
