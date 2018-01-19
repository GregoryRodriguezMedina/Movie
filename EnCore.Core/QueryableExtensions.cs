using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnCore.Core
{
    public static partial class QueryableExtensions
    {
        public static IQueryResponse<TEntity> Paging<TEntity>(this IQueryable<TEntity> source, IQueryRequest queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.Per_page <= 0)
                queryObj.Per_page = 10;


            int itemCount = source.Count();

            source = source.Skip((queryObj.Page - 1) * queryObj.Per_page)
                         .Take(queryObj.Per_page);

            var items = source.ToList();

            return new QueryResponse<TEntity>
            {
                Items = items,
                ItemCount = itemCount
            };
        }
    }
}
