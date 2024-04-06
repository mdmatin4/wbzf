using wbzf.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.viewComponents
{
    public class SchemeListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IUnitOfWork _unitOfWork, int pageIndex, int pageSize, string? sortColumn, string? sortDirection, string? searchTerm)
        {
            var isDescending = sortDirection?.ToLower() == "desc";


            // var filterExpression = MultiColumnSearch(searchTerm, txndate, userid);
            var schemes = _unitOfWork.scheme.GetAll(orderby: BuildOrderByExpression(sortColumn, isDescending),
                filter: MultiColumnSearch( searchTerm),
                pageNumber: pageIndex,
                pageSize: pageSize, includeProperties: "Purpose").ToList();

            var totalCount = await _unitOfWork.scheme.GetCountAsync(filter: MultiColumnSearch(searchTerm));

            var vmodel = PaginatedList<Scheme>.Create(schemes, totalCount, pageIndex, pageSize);

            return View(vmodel);
        }

        private Expression<Func<Scheme, bool>> MultiColumnSearch(string? searchTerm)
        {
            // Make the search case-insensitive
            // Convert the search term to lowercase

            Expression<Func<Scheme, bool>> filter = null;
            Expression<Func<Scheme, bool>> filter2 = null;
            if (searchTerm?.Length > 0)
            {

                searchTerm = searchTerm.ToLower();

                filter = c =>
                    c.Name.ToLower().Contains(searchTerm)
                    || c.Purpose.Name.ToLower().Contains(searchTerm)
                    || c.Form_Url.ToLower().Contains(searchTerm);

            }
           
            return filter;

        }



        private Func<IQueryable<Scheme>, IOrderedQueryable<Scheme>> BuildOrderByExpression(string sortColumn, bool isDescending)
        {
            Func<IQueryable<Scheme>, IOrderedQueryable<Scheme>> orderBy = null;

            switch (sortColumn?.ToLower())
            {
                case "name":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.Name) : cases.OrderBy(c => c.Name);
                    break;
                case "purpose":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.Purpose.Name) : cases.OrderBy(c => c.Purpose.Name);
                    break;
                case "formurl":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.Form_Url) : cases.OrderBy(c => c.Form_Url);
                    break;
                default:
                    orderBy = cases => cases.OrderByDescending(c => c.Created_at);
                    // Set a default sorting order here if needed
                    break;

            }

            return orderBy;
        }

    }
}
