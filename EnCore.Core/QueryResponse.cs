using System;
using System.Collections.Generic;
using System.Text;

namespace EnCore.Core
{
    public interface IQueryResponse<TEntity>
    {
        int ItemCount { get; set; }
        IEnumerable<TEntity> Items { get; set; }
    }

    public class QueryResponse<TEntity> : IQueryResponse<TEntity>
    {
        public int ItemCount { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
    }
}
