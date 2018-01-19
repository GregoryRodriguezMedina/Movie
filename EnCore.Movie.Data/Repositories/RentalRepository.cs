using EnCore.Core;
using EnCore.Movie.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnCore.Movie.Data
{
    public partial interface IRentalRepository : EnCore.Core.IEfRepositoryBase<Rental>
    {
        Rental GetByCustomerId(int customerId);
        //IEnumerable<RentalResponse> Get(QueryRequest queryRequest);
    }

    public class RentalRepository : EnCore.Core.EfRepositoryBase<Rental>, IRentalRepository
    {
        private readonly DbContext context;

        public RentalRepository(DbContext context) : base(context)
        {
            this.context = context;
        }

        public Rental GetByCustomerId(int customerId)
        {
            var query = this.Entity
                    .Include(a => a.RentalDetails)
                    .Where(a=> a.CustomerId == customerId);

            return query.FirstOrDefault();
        }

        public override Rental GetById(int key)
        {
            return GetQueryable().FirstOrDefault();                      
        }

        private IQueryable<Rental> GetQueryable() {
            IQueryable<Rental> queryable = this.Entity
                   .Include(a => a.RentalDetails)
                   .Include(a => a.Customer);

            return queryable;
        }

        public override IQueryResponse<Rental> Get(QueryRequest queryRequest)
        {
            return GetQueryable()
                   .OrderBy(a=> a.Status)
                   .Paging(queryRequest);
            //return base.Get(queryRequest);
        }

    }
}