using AlManalChickens.Domain.Common.Helpers.DataTablePaginationServer;
using System.Linq.Expressions;

namespace AlManalChickens.Domain.Common.Helpers
{
    public class AppService : IAppService
    {


            public List<T> GetData<T>(PaginationConfiguration outf, IQueryable<T> customerData, Expression<Func<T, bool>> condition)
        {

            //Sorting
            //if (!(string.IsNullOrEmpty(outf.sortColumn) && string.IsNullOrEmpty(outf.sortColumnDirection)))
            //{
            //    //customerData = customerData.OrderBy(o => outf.sortColumn + " " + outf.sortColumnDirection);
            //    customerData = customerData.OrderBy(o => outf.sortColumn);
            //}
            //Search
            if (!string.IsNullOrEmpty(outf.searchValue))
            {
                customerData = customerData.Where(condition);
            }

            //total number of rows count 
            outf.recordsTotal = customerData.Count();
            //Paging 

            //var data = customerData.OrderBy(o => outf.sortColumn + " " + outf.sortColumnDirection);
            var data = customerData.Skip(outf.skip).Take(outf.pageSize).ToList();


            return data;
        }


    }
}
