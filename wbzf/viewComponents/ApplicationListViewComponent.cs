using wbzf.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using wbzf.DataAccess.Repository.IRepository;
using wbzf.Model;

namespace wbzf.viewComponents
{
    public class ApplicationListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IUnitOfWork _unitOfWork, int pageIndex, int pageSize, string? sortColumn, string? sortDirection, string? searchTerm, int? schemeId, string? stutus, int? purposeId)
        {
            var isDescending = sortDirection?.ToLower() == "desc";


            // var filterExpression = MultiColumnSearch(searchTerm, txndate, userid);
            var applications = _unitOfWork.applicationRegister.GetAll(orderby: BuildOrderByExpression(sortColumn, isDescending),
                filter: MultiColumnSearch(searchTerm, schemeId, stutus, purposeId),
                pageNumber: pageIndex,
                pageSize: pageSize, includeProperties: "Scheme,Profession,Purpose").ToList();

            var totalCount = await _unitOfWork.applicationRegister.GetCountAsync(filter: MultiColumnSearch(searchTerm, schemeId, stutus, purposeId));

            var vmodel = PaginatedList<ApplicationRegister>.Create(applications, totalCount, pageIndex, pageSize);

            return View(vmodel);
        }

        private Expression<Func<ApplicationRegister, bool>> MultiColumnSearch(string? searchTerm, int? schemeId, string? status, int? purposeId)
        {
            // Make the search case-insensitive
            // Convert the search term to lowercase

            Expression<Func<ApplicationRegister, bool>> filter = null;
            Expression<Func<ApplicationRegister, bool>> filter2 = null;
            Expression<Func<ApplicationRegister, bool>> filter3 = null;
            Expression<Func<ApplicationRegister, bool>> filter4 = null;
            Expression<Func<ApplicationRegister, bool>> filter5 = null;

            if (searchTerm?.Length > 0)
            {

                searchTerm = searchTerm.ToLower();

                filter = c =>
                    c.Full_Name.ToLower().Contains(searchTerm)
                    || c.Scheme.Name.ToLower().Contains(searchTerm)
                    || c.Father_name.ToLower().Contains(searchTerm)
                    || c.guardianName.ToLower().Contains(searchTerm)
                    || c.Mother_name.ToLower().Contains(searchTerm)
                    || c.created_at.ToString().Contains(searchTerm)
                    || c.DateofBirth.ToString().Contains(searchTerm)
                    || c.PhoneNumber.ToString().Contains(searchTerm)
                    || c.application_Status.ToLower().Contains(searchTerm);

            }
            if (purposeId != null)
            {
               string currentpurposeId = purposeId.ToString();

                filter2 = c => c.PurposeId == purposeId;
                if (filter != null)
                {
                    filter = Expression.Lambda<Func<ApplicationRegister, bool>>(
                    Expression.AndAlso(filter.Body, new ExpressionParameterReplacer(filter2.Parameters, filter.Parameters).Visit(filter2.Body)),
                    filter.Parameters[0]);
                }
                else
                {
                    filter = filter2;
                }
            }
            if (schemeId != null)
            {
                filter3 = c => c.SchemeId == schemeId;
                if (filter != null)
                {
                    filter = Expression.Lambda<Func<ApplicationRegister, bool>>(
                    Expression.AndAlso(filter.Body, new ExpressionParameterReplacer(filter3.Parameters, filter.Parameters).Visit(filter3.Body)),
                    filter.Parameters[0]);
                }
                else
                {
                    filter = filter3;
                }
            }
            if (status != null)
            {
                filter4 = c => c.application_Status == status;
                if (filter != null)
                {
                    filter = Expression.Lambda<Func<ApplicationRegister, bool>>(
                    Expression.AndAlso(filter.Body, new ExpressionParameterReplacer(filter4.Parameters, filter.Parameters).Visit(filter4.Body)),
                    filter.Parameters[0]);
                }
                else
                {
                    filter = filter4;
                }
            }
            if (status != null && schemeId != null)
            {
                filter5 = c => c.application_Status == status && c.SchemeId == schemeId;
                if (filter != null)
                {
                    filter = Expression.Lambda<Func<ApplicationRegister, bool>>(
                    Expression.AndAlso(filter.Body, new ExpressionParameterReplacer(filter5.Parameters, filter.Parameters).Visit(filter5.Body)),
                    filter.Parameters[0]);
                }
                else
                {
                    filter = filter5;
                }
            }

            return filter;

        }



        private Func<IQueryable<ApplicationRegister>, IOrderedQueryable<ApplicationRegister>> BuildOrderByExpression(string sortColumn, bool isDescending)
        {
            Func<IQueryable<ApplicationRegister>, IOrderedQueryable<ApplicationRegister>> orderBy = null;

            switch (sortColumn?.ToLower())
            {
                case "name":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.Full_Name) : cases.OrderBy(c => c.Full_Name);
                    break;
                case "schemeName":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.Scheme.Name) : cases.OrderBy(c => c.Scheme.Name);
                    break;
                case "applicationDate":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.created_at) : cases.OrderBy(c => c.created_at);
                    break;
                case "applicationStatus":
                    orderBy = cases => isDescending ? cases.OrderByDescending(c => c.application_Status) : cases.OrderBy(c => c.application_Status);
                    break;

                default:
                    orderBy = cases => cases.OrderByDescending(c => c.created_at);
                    // Set a default sorting order here if needed
                    break;

            }

            return orderBy;
        }

    }
}
